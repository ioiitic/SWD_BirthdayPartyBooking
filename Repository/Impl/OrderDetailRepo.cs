using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class OrderDetailRepo : BaseRepo<OrderDetail>, IOrderDetailRepo
    {
        public OrderDetailRepo(BirthdayPartyBookingContext context)
            : base(context)
        {
        }
        public List<OrderDetail> GetOrderDetailByOrderID(Guid id)
        {
            try
            {
                return _context.OrderDetails.AsNoTracking()
                                                  .Where(o => o.OrderId == id)
                                                  .Include(o => o.Service)
                                                  .Include(o => o.Service.ServiceType)
                                                  .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
