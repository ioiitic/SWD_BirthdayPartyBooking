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
        public AccountService(IRepoWrapper repoWrapper)
            : base(repoWrapper)
        {
        }
    }
}
