﻿using BusinessObject;
using BusinessObject.DTO.PlaceDTO;
using BusinessObject.DTO.RequestDTO;
using BusinessObject.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderService : IBaseService<Order>
    {
        List<Order> GetOrderByHostID(Guid id);
        List<Order> GetOrderByCustomerID(Guid id);
        Order GetOrderByOrderID(Guid id);
        bool CheckOrderExist(Order order, Guid Id);
        bool Remove(Guid Id);
        ServiceResponse<object> Booking(Guid customerId, Guid hostId, DateTime dateBooking, string note, PlaceView place, List<BookingServiceRequest> serviceRequest);
    }
}
