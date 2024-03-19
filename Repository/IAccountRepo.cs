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
        Task<bool> CheckEmailExist(string email);
        List<Account> GetAllActiveHosts();
        bool Remove(Guid Id);
        Account GetAccountById(Guid Id);
        bool Save();
    }
}
