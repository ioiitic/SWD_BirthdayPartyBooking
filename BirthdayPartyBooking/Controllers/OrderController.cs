﻿using BusinessObject;
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

        public OrderController(IServiceWrapper service, IOrderService orderService)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400)]
        public IActionResult GetOrderByCustomerID(Guid customerId)
        {
            if(customerId == Guid.Empty)
            {
                return BadRequest(ModelState);
            }
            var order = _service.Order.GetOrderByCustomerID(customerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(order);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400)]
        public IActionResult GetOrderByHostID(Guid hostId)
        {
            if (hostId == Guid.Empty)
            {
                return BadRequest(ModelState);
            }
            var order = _service.Order.GetOrderByHostID(hostId);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(order);
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

        [HttpPut("[action]/{orderId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult CancelOrder(Guid orderId)
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
            checkOrders.Status = 3;
            _service.Order.Update(checkOrders);
            return Ok("Successfully updated");
        }

    }
}
