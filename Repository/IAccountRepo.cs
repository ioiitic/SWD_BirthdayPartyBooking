using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAccountRepo : IBaseRepo<Account>
    {
        Task<Account> CheckLogin(string Email, string Password);
        bool CheckEmailExist(string email);
        List<Account> GetAllActiveHosts();
        Task Remove(Guid Id);
        Task AddNew(Account account);
        Account GetAccountById(Guid Id);
    }
}
