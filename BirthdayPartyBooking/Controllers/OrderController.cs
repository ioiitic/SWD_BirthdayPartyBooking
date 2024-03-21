using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System;
using Services.Impl;
using BusinessObject.DTO.RequestDTO;
using System.Net;
using System.Threading.Tasks;
using BusinessObject.DTO.ResponseDTO;

namespace BirthdayPartyBooking.Controller
{
    [ApiController]
    [Route("api/")]
    public class OrderController : ControllerBase
    {
        private IServiceWrapper _service;

        public OrderController(IServiceWrapper service, IOrderService orderService)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public IActionResult GetOrderByCustomerID(Guid customerId)
        {          
            var order = _service.Order.GetOrderByCustomerID(customerId);

            if (order.Success == false)
            {
                return BadRequest(order);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new ServiceResponse<object>(false));
            }
         
            return Ok(order);
        }

        [HttpGet("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public IActionResult GetOrderByHostID(Guid hostId)
        {           
            var order = _service.Order.GetOrderByHostID(hostId);

            if (order.Success == false)
            {
                return Conflict(order);
            }

            if (!ModelState.IsValid)
                return BadRequest(new ServiceResponse<object>(false));

            return Ok(order);
        }

        [HttpPost("[action]")]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public IActionResult Booking([FromBody] BookingRequest bookingRequest)
        {
            var booking = _service.Order.Booking(bookingRequest);
            
            if (booking.Success == false)
            {
                return BadRequest(booking);
            }

            return Ok(booking);
        }

        [HttpPut("[action]/{orderId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOrder(Guid orderId, int status)
        {                     
            var checkOrders = _service.Order.UpdateOrderStatus(orderId, status);    
            
            if(checkOrders.Success == false)
            {
                return BadRequest(checkOrders);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new ServiceResponse<object>(false));
            }
 
            return Ok(checkOrders);
        }

        [HttpPut("[action]/{orderId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult CancelOrder(Guid orderId)
        {
            var cancelOrder = _service.Order.CancelOrder(orderId);
            if (cancelOrder.Success == false)
            {
                return BadRequest(cancelOrder);
            }
            if (!ModelState.IsValid)
                return BadRequest(new ServiceResponse<object>(false));
            
            return Ok(cancelOrder);
        }

    }
}
