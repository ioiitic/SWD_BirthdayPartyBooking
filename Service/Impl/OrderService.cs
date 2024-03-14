using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        public OrderService(IRepoWrapper repoWrapper)
            : base(repoWrapper)
        {
        }
    }
}
