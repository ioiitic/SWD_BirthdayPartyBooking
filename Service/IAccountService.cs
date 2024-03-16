using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAccountService : IBaseService<Account>
    {
        Account CheckLogin(string Email, string Password);
        bool CheckEmailExist(string email);
        List<Account> GetAllActiveHosts();
        Task Remove(Guid Id);
    }
}
