using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {
        public OrderRepo(BirthdayPartyBookingContext context)
            : base(context)
        {
        }
    }
}
