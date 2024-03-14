using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class AccountRepo : BaseRepo<Account>, IAccountRepo
    {
        public AccountRepo(BirthdayPartyBookingContext context)
            : base(context)
        {
        }
    }
}
