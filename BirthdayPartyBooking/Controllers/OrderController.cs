using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System;
using Services.Impl;

namespace BirthdayPartyBooking.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private IServiceWrapper _service;
        private IOrderService _orderService;

        public OrderController(IServiceWrapper service, IOrderService orderService)
        {
            _service = service;
            _orderService = orderService;
        }

        [HttpPut("[action]/{orderId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOrder(Guid orderId, int status)
        {
            if (orderId == Guid.Empty)
            {
                return BadRequest(ModelState);
            }
           
            var checkOrders = _service.Order.GetOrderByOrderID(orderId);    

            if (checkOrders==null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            checkOrders.Status = status;
            _service.Order.Update(checkOrders);
            return Ok("Successfully updated");
        }

    }
}
