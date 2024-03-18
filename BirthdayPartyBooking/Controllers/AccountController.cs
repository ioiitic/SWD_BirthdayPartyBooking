using BusinessObject;
using BusinessObject.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayPartyBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private IServiceWrapper _service;
        private IAccountService _accountService;

        public AccountController(IServiceWrapper service, IAccountService accountService)
        {
            _service = service;
            _accountService=accountService;
        }

        [HttpGet("[action]")]
        public IEnumerable<Account> GetAllAccounts()
        {
            var accounts = _service.Account.GetAll();

            return accounts;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(Account))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> SignIn(string Email, string Password)
        {

            var accounts = await _accountService.CheckLogin(Email, Password);
            if (accounts == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tokenCustomer = new
            {
                accounts,
                token = GenerateToken(accounts)
            };

            return Ok(tokenCustomer);
        }

        private string GenerateToken(Account account)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            var secretKeyBytes = Encoding.UTF8.GetBytes(configuration.GetConnectionString("SecretKey"));

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Role, UserRole.Role[account.Role.Value]),
                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                    (secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(Account))]
        [ProducesResponseType(400)]
        public IActionResult GetAccount(Guid Id)
        {

            var accounts = _service.Account.GetById(Id);

            if (accounts.DeleteFlag != 0)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(accounts);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult SignUp([FromBody] Account account)
        {
            if (account == null)
            {
                return BadRequest(ModelState);
            }
            var checkAccount = _accountService.CheckEmailExist(account.Email);
            if (checkAccount)
            {
                ModelState.AddModelError("", "This email already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _accountService.AddNew(account);
            return Ok("Successfully created");
        }

        [HttpPut("[action]/{accountId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAccount(Guid accountId, [FromBody] Account account)
        {
            if (account == null)
            {
                return BadRequest(ModelState);
            }
            if (accountId != account.Id)
            {
                return BadRequest(ModelState);
            }
            var checkAccounts = _accountService.GetAccountById(accountId);
            if (checkAccounts==null || checkAccounts.DeleteFlag != 0)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.Account.Update(account);  
            return Ok("Successfully updated");
        }
    }
}
