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
        public IAccountRepo accountRepo;
        public AccountService(IRepoWrapper repoWrapper, IAccountRepo accountRepo)
            : base(repoWrapper)
        {
            this.accountRepo = accountRepo;
        }

        public Task AddNew(Account account) => accountRepo.AddNew(account); 

        public bool CheckEmailExist(string email) => accountRepo.CheckEmailExist(email);

        public Account CheckLogin(string Email, string Password) => accountRepo.CheckLogin(Email, Password);

        public Account GetAccountById(Guid Id) => accountRepo.GetAccountById(Id);

        public List<Account> GetAllActiveHosts()=> accountRepo.GetAllActiveHosts();

        public Task Remove(Guid Id) => accountRepo.Remove(Id);  

    }
}
