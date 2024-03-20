using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Net;
using BusinessObject.DTO.ResponseDTO;

namespace BirthdayPartyBooking.Controllers
{
    [ApiController]
    [Route("api/")]
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
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public IActionResult GetOrderDetail(Guid orderId)
        {
            var orderDetail = _service.OrderDetail.GetOrderDetailByOrderID(orderId);
            if(orderDetail.Success == false)
            {
                return BadRequest(orderDetail);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(new ServiceResponse<object>(false));
            }
            return Ok(orderDetail);
        }
    }
}
