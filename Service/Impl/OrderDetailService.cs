using AutoMapper;
using BusinessObject;
using BusinessObject.DTO.ResponseDTO;
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

        public ServiceResponse<List<OrderDetail>> GetOrderDetailByOrderID(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new ServiceResponse<List<OrderDetail>>(false, "Id is null.");
            }
            var listOrderDetail = _repoWrapper.OrderDetail.GetOrderDetailByOrderID(id);
            return new ServiceResponse<List<OrderDetail>>(listOrderDetail);
        }
    }
}
