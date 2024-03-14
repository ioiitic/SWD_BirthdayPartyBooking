using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class ServiceTypeRepo : BaseRepo<ServiceType>, IServiceTypeRepo
    {
        public ServiceTypeRepo(BirthdayPartyBookingContext context)
            : base(context)
        {
        }
    }
}
