using AutoMapper;
using BusinessObject;
using BusinessObject.DTO.AccountDTO;
using BusinessObject.DTO.RequestDTO;
using BusinessObject.DTO.ResponseDTO;
using Repository;
using Services.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class AccountService : BaseService<Account>, IAccountService
    {
        public AccountService(IRepoWrapper repoWrapper, IMapper mapper)
            : base(repoWrapper, mapper)
        {
        }

        public async Task<ServiceResponse<object>> SignIn(string Email, string Password)
        {
            var account = await _repoWrapper.Account.CheckAccountExist(Email, Password);

            if (account == null)
            {
                return new ServiceResponse<object>(false, "Wrong email or password!");
            }

            var accountDTO = _mapper.Map<SignInDTO>(account);
            var tokenCustomer = JWTUtils.GenerateToken(accountDTO);

            return new ServiceResponse<object>(tokenCustomer);
        }

        public async Task<ServiceResponse<object>> SignUp(SignUpRequest signUpRequest)
        {
            var checkAccount = await _repoWrapper.Account.CheckEmailExist(signUpRequest.Email);

            if (checkAccount)
            {
                return new ServiceResponse<object>(false, "Duplicate Email!");
            }

            var accountSignUp = _mapper.Map<Account>(signUpRequest);
            _repoWrapper.Account.Insert(accountSignUp);

            return new ServiceResponse<object>(true, "Sign up successfully");
        }

        public ServiceResponse<object> Update(Guid accountId, AccountUpdateRequest accountUpdateRequest)
        {
            var checkAccounts = _repoWrapper.Account.GetAccountById(accountId);

            if (checkAccounts == null)
            {
                return new ServiceResponse<object>(false, "Not found Account");
            }

            checkAccounts = _mapper.Map(accountUpdateRequest, checkAccounts);

            _repoWrapper.Account.Update(checkAccounts);
            return new ServiceResponse<object>(true, "Update successfully.");
        }

        public ServiceResponse<Account> GetAccountById(Guid Id)
        {
            var account = _repoWrapper.Account.GetAccountById(Id);
            if (account == null||account.DeleteFlag != 0)
                return new ServiceResponse<Account>(false, "Not found");
            return new ServiceResponse<Account>(account);
        }

        public bool Remove(Guid Id) => _repoWrapper.Account.Remove(Id);

        public ServiceResponse<List<Account>> GetAllHost()
        {
            var listHost = _repoWrapper.Account.GetAllActiveHosts();
            return new ServiceResponse<List<Account>>(listHost);
        }
    }
}
