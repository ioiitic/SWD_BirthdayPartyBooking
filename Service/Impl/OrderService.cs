using AutoMapper;
using BusinessObject;
using BusinessObject.DTO.PlaceDTO;
using BusinessObject.DTO.RequestDTO;
using BusinessObject.DTO.ResponseDTO;
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

        public ServiceResponse<object> Booking(Guid customerId, Guid hostId, DateTime dateBooking, string note, PlaceView place, List<BookingServiceRequest> serviceRequest)
        {
            int? totalPrice = place.Price;
            Order newBooking = new Order
            {
                GuestId = customerId,
                HostId = hostId,
                PlaceId = place.Id,
                Date = dateBooking,
                OrderDate = DateTime.Now,
                Note = note,
                DeleteFlag = 0,
                Status = 0
            };
            _repoWrapper.Order.Insert(newBooking);

            foreach(var item in serviceRequest)
            {
                var getService = _repoWrapper.Service.GetServiceByServiceID(item.Id);
                OrderDetail newDetail = new OrderDetail
                {
                    Price = getService.Price,
                    ServiceId = item.Id,
                    OrderId = newBooking.Id,
                    Number = item.Quantity
                };
                totalPrice += newDetail.Price;
                _repoWrapper.OrderDetail.Insert(newDetail);
            }

            newBooking.TotalPrice = totalPrice;
            _repoWrapper.Order.Update(newBooking);
            return new ServiceResponse<object>(true, "Booking successfully.");
        }

        public bool CheckOrderExist(Order order, Guid Id) => _repoWrapper.Order.CheckOrderExist(order, Id);

        public List<Order> GetOrderByCustomerID(Guid id) => _repoWrapper.Order.GetOrderByCustomerID(id);

        public List<Order> GetOrderByHostID(Guid id) => _repoWrapper.Order.GetOrderByHostID(id);

        public Order GetOrderByOrderID(Guid id) => _repoWrapper.Order.GetOrderByOrderID(id);

        public bool Remove(Guid Id) => _repoWrapper.Order.Remove(Id);
    }
}
