using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class OrderDetailService : BaseService<OrderDetail>, IOrderDetailService
    {
        public IOrderDetailRepo orderDetailRepo;
        public OrderDetailService(IRepoWrapper repoWrapper, IOrderDetailRepo orderDetailRepo)
            : base(repoWrapper)
        {
            this.orderDetailRepo=orderDetailRepo;
        }

        public Task<List<OrderDetail>> GetOrderDetailByOrderID(Guid id) => orderDetailRepo.GetOrderDetailByOrderID(id); 
    }
}
