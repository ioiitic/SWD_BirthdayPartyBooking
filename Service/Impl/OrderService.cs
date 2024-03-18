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
        private IOrderRepo _orderRepo;
        public OrderService(IRepoWrapper repoWrapper, IOrderRepo orderRepo)
            : base(repoWrapper)
        {
            _orderRepo = orderRepo;
        }

        public bool CheckOrderExist(Order order, string Id) => _orderRepo.CheckOrderExist(order, Id);   

        public List<Order> GetOrderByCustomerID(string id) => _orderRepo.GetOrderByCustomerID(id);

        public List<Order> GetOrderByHostID(string id) => _orderRepo.GetOrderByHostID(id);

        public Order GetOrderByOrderID(Guid id) => _orderRepo.GetOrderByOrderID(id);

        public void Remove(Guid Id) => _orderRepo.Remove(Id);
    }
}
