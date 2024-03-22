using BusinessObject;
using BusinessObject.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderDetailService : IBaseService<OrderDetail>
    {
        ServiceResponse<List<OrderDetailResponse>> GetOrderDetailByOrderID(Guid id);
    }
}
