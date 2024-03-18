using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderRepo : IBaseRepo<Order>
    {
        List<Order> GetOrderByHostID(Guid id);
        List<Order> GetOrderByCustomerID(Guid id);
        Order GetOrderByOrderID(Guid id);
        bool CheckOrderExist(Order order, Guid Id);
        bool Remove(Guid Id);
        bool Save();
    }
}
