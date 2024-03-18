using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        public IActionResult SignIn(string Email, string Password)
        {

            var accounts = _accountService.CheckLogin(Email, Password);
            if (accounts == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(accounts);
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
