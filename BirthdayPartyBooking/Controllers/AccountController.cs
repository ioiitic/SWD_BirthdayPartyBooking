using BirthdayPartyBooking.Filter;
using BusinessObject;
using BusinessObject.DTO.RequestDTO;
using BusinessObject.DTO.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BirthdayPartyBooking.Controllers
{
    [ApiController]
    [Route("api/")]
    public class AccountController : ControllerBase
    {
        private IServiceWrapper _service;

        public AccountController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpPost("auth/[action]")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [CustomValidationFilter]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest signInRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ServiceResponse<object>(false, "Moi"));
            }
            var response = await _service.Account.SignIn(signInRequest.Email, signInRequest.Password);

            if (response.Success == false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost("auth/[action]")]
        [ProducesResponseType((int) HttpStatusCode.Conflict)]
        [ProducesResponseType((int) HttpStatusCode.Created)]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest signUpRequest)
        {
            var signUpResponse = await _service.Account.SignUp(signUpRequest);
            
            if (signUpResponse.Success == false)
            {
                return Conflict(signUpResponse);
            }

            return Created("auth/[action]", signUpResponse);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(Account))]
        [ProducesResponseType(400)]
        public IActionResult GetAccount(Guid Id)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

            var accounts = _service.Account.GetAccountById(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(accounts);
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
            var checkAccounts = _service.Account.GetAccountById(accountId);
            if (checkAccounts==null)
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
