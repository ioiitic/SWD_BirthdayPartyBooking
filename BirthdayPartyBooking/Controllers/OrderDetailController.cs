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
    public class OrderDetailController : ControllerBase
    {
        private IServiceWrapper _service;
        private IOrderDetailService _orderDetailService;

        public OrderDetailController(IServiceWrapper service, IOrderDetailService orderDetailService)
        {
            _service = service;
            _orderDetailService= orderDetailService;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(OrderDetail))]
        [ProducesResponseType(400)]
        public IActionResult GetOrderDetail(Guid orderId)
        {
            var orderDetail = _service.OrderDetail.GetOrderDetailByOrderID(orderId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(orderDetail);
        }
    }
}
