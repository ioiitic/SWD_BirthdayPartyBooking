using BusinessObject.DTO.RequestDTO;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.DTO.ResponseDTO;

namespace Services
{
    public interface IAccountService : IBaseService<Account>
    {
        Task<ServiceResponse<Object>> SignIn(string Email, string Password);
        Task<ServiceResponse<Object>> SignUp(SignUpRequest signUpRequest);
        List<Account> GetAllActiveHosts();
        bool Remove(Guid Id);
        ServiceResponse<Account> GetAccountById(Guid Id);
    }
}
