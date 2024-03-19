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
    public class OrderService : BaseService<Order>, IOrderService
    {
        public OrderService(IRepoWrapper repoWrapper, IMapper mapper) : base(repoWrapper, mapper)
        {
        }

        public bool CheckOrderExist(Order order, Guid Id) => _repoWrapper.Order.CheckOrderExist(order, Id);   

        public List<Order> GetOrderByCustomerID(Guid id) => _repoWrapper.Order.GetOrderByCustomerID(id);

        public List<Order> GetOrderByHostID(Guid id) => _repoWrapper.Order.GetOrderByHostID(id);

        public Order GetOrderByOrderID(Guid id) => _repoWrapper.Order.GetOrderByOrderID(id);

        public bool Remove(Guid Id) => _repoWrapper.Order.Remove(Id);
    }
}
