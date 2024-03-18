﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderDetailService : IBaseService<OrderDetail>
    {
        List<OrderDetail> GetOrderDetailByOrderID(Guid id);
    }
}
