using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderDetailRepo : IBaseRepo<OrderDetail>
    {
        Task<List<OrderDetail>> GetOrderDetailByOrderID(Guid id);
    }
}
