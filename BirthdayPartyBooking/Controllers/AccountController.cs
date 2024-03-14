using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

namespace BirthdayPartyBooking.Controllers
{
    [ApiController]
    [Route("Account")]
    public class AccountController
    {
        private IServiceWrapper _service;

        public AccountController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Account> GetAll()
        {
            var accounts = _service.Account.GetAll();

            return accounts;
        }
    }
}
