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
    [Route("[controller]")]
    public class AccountController
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
        public IEnumerable<Account> GetAllAsscountIncludeChildren(string[] children)
        {
            var accounts = _service.Account.GetAll(children);

            return accounts;
        }

        //[HttpGet("[action]")]
        //public IEnumerable<Account> GetAllAccount([FromQuery] int deleteFlag)
        //{
        //    var accounts = _service.Account.GetAll(a => a.DeleteFlag == deleteFlag);

        //    return accounts;
        //}

        [HttpGet("[action]")]
        public List<Account> GetAllActiveHosts()
        {
            var accounts = _accountService.GetAllActiveHosts();

            return accounts;
        }

        [HttpGet("[action]")]
        public Account GetAccountByAccountID(Guid id)
        {
            var account = _accountService.GetById(id);

            return account;
        }

        [HttpPut("[action]")]
        public bool CheckEmailExist(string email)
        {
            var accounts = _accountService.CheckEmailExist(email);

            return accounts;
        }

        [HttpPut("[action]")]
        public Account CheckLogin(string Email, string Password)
        {
            var accounts = _accountService.CheckLogin(Email, Password);

            return accounts;
        }

        [HttpPut("[action]")]
        public void InsertAccount(Account account)
        {
            _service.Account.Insert(account);       
        }

        [HttpPut("[action]")]
        public void UpdateAccount(Account account)
        {
            _service.Account.Update(account);
        }

        [HttpDelete("[action]")]
        public async Task Remove(Guid Id)
        {
            await _accountService.Remove(Id); 
        }
    }
}
