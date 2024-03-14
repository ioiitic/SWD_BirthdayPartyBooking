using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class ServiceRepo : BaseRepo<Service>, IServiceRepo
    {
        public ServiceRepo(BirthdayPartyBookingContext context)
            : base(context)
        {
        }
    }
}
