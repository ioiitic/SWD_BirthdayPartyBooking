using AutoMapper;
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
        public OrderDetailService(IRepoWrapper repoWrapper, IMapper mapper) : base(repoWrapper, mapper)
        {
        }

        public List<OrderDetail> GetOrderDetailByOrderID(Guid id) => _repoWrapper.OrderDetail.GetOrderDetailByOrderID(id); 
    }
}
