using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class AccountService : BaseService<Account>, IAccountService
    {
        public AccountService(IRepoWrapper repoWrapper, IAccountRepo accountRepo)
            : base(repoWrapper)
        {
        }

        public bool AddNew(Account account) => _repoWrapper.Account.AddNew(account); 

        public bool CheckEmailExist(string email) => _repoWrapper.Account.CheckEmailExist(email);

        public Account CheckLogin(string Email, string Password) => _repoWrapper.Account.CheckLogin(Email, Password);

        public Account GetAccountById(Guid Id) => _repoWrapper.Account.GetAccountById(Id);

        public List<Account> GetAllActiveHosts()=> _repoWrapper.Account.GetAllActiveHosts();

        public bool Remove(Guid Id) => _repoWrapper.Account.Remove(Id);  

    }
}
