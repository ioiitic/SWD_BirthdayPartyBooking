using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BirthdayPartyBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailController
    {
        private IServiceWrapper _service;
        private IOrderDetailService _orderDetailService;

        public OrderDetailController(IServiceWrapper service, IOrderDetailService orderDetailService)
        {
            _service = service;
            _orderDetailService= orderDetailService;
        }

        [HttpGet("[action]")]
        public async Task<List<OrderDetail>> GetAllOrderDetailOfOrder(Guid Id) 
        {
            return await _orderDetailService.GetOrderDetailByOrderID(Id);
            
        }

        [HttpPut("[action]")]
        public void InsertAccount(Order order)
        {
            _service.Order.Insert(order);
        }

    }
}
