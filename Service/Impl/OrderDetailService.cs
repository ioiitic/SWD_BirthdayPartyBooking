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

        public ServiceResponse<List<OrderDetailResponse>> GetOrderDetailByOrderID(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new ServiceResponse<List<OrderDetailResponse>>(false, "Id is null.");
            }

            var listOrderDetail = _repoWrapper.OrderDetail.GetOrderDetailByOrderID(id);
            var listOrderDeatailResponse = listOrderDetail
                .Select(orderDetail => _mapper.Map<OrderDetailResponse>(orderDetail))
                .ToList();

            return new ServiceResponse<List<OrderDetailResponse>>(listOrderDeatailResponse);
        }
    }
}
