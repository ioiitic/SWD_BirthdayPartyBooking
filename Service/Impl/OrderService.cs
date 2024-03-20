﻿using AutoMapper;
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
            if (customerId == Guid.Empty || hostId == Guid.Empty)
            {
                return new ServiceResponse<object>(false, "Id is null.");
            }
            if (place == null||serviceRequest == null)
            {
                return new ServiceResponse<object>(false, "Object is null.");
            }
            if(dateBooking > DateTime.Now.AddYears(1))
            {
                return new ServiceResponse<object>(false, "Date is to far.");

            }
            else if(dateBooking < DateTime.Now.AddDays(2))
            {
                return new ServiceResponse<object>(false, "Date must be booked 2 days early.");
            }
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
            var checkExist = _repoWrapper.Order.CheckOrderExist(newBooking, hostId);
            if (checkExist)
            {
                return new ServiceResponse<object>(false, "Booking is overlap.");
            }
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

        public ServiceResponse<object> CancelOrder(Guid Id)
        {
            var checkOrders = _repoWrapper.Order.GetOrderByOrderID(Id);

            if (checkOrders==null)
            {
                return new ServiceResponse<object>(false, "Order NotFound");
            }
            if(Id == Guid.Empty)
            {
                return new ServiceResponse<object>(false, "Id is null");
            }
            
            checkOrders.Status = 6;
            _repoWrapper.Order.Update(checkOrders);

            return new ServiceResponse<object>(true, "Cancel successfully");
        }

        public bool CheckOrderExist(Order order, Guid Id) => _repoWrapper.Order.CheckOrderExist(order, Id);

        public ServiceResponse<List<Order>> GetOrderByCustomerID(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new ServiceResponse<List<Order>>(false, "Id is null");
            }
            var listOrder = _repoWrapper.Order.GetOrderByCustomerID(id);
            return new ServiceResponse<List<Order>>(listOrder);
        }
        public ServiceResponse<List<Order>> GetOrderByHostID(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new ServiceResponse<List<Order>>(false, "Id is null");
            }
            var listOrder = _repoWrapper.Order.GetOrderByHostID(id);
            return new ServiceResponse<List<Order>>(listOrder);
        }
        public Order GetOrderByOrderID(Guid id) => _repoWrapper.Order.GetOrderByOrderID(id);

        public bool Remove(Guid Id) => _repoWrapper.Order.Remove(Id);

        public ServiceResponse<object> UpdateOrderStatus(Guid Id, int Status)
        {
            var checkOrders = _repoWrapper.Order.GetOrderByOrderID(Id);

            if (checkOrders==null)
            {
                return new ServiceResponse<object>(false, "Order Notfound");
            }
            if(Status<0)
            {
                return new ServiceResponse<object>(false, "Invalid status");
            }          
            
            checkOrders.Status = Status;
            
            _repoWrapper.Order.Update(checkOrders);

            return new ServiceResponse<object>(true, "Update Status successfully.");
        }
    }
}
