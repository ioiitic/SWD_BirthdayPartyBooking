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
        Account CheckLogin(string Email, string Password);
        bool CheckEmailExist(string email);
        List<Account> GetAllActiveHosts();
        bool Remove(Guid Id);
        bool AddNew(Account account);
        Account GetAccountById(Guid Id);
        bool Save();
    }
}
