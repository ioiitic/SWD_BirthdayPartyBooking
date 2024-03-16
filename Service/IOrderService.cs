﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderService : IBaseService<Order>
    {
        List<Order> GetOrderByHostID(string id);
        List<Order> GetOrderByCustomerID(string id);
        Order GetOrderByOrderID(Guid id);
        bool CheckOrderExist(Order order, string Id);
        void Remove(Guid Id);
    }
}
