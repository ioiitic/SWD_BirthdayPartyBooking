using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System;

namespace BirthdayPartyBooking.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController
    {
        private IServiceWrapper _service;
        private IOrderService _orderService;

        public OrderController(IServiceWrapper service, IOrderService orderService)
        {
            _service = service;
            _orderService = orderService;
        }

        [HttpGet("[action]")]
        public IEnumerable<Order> GetAllOrders()
        {
            var accounts = _service.Order.GetAll();

            return accounts;
        }

        [HttpGet("[action]")]
        public IEnumerable<Order> GetAllOrderIncludeChildren(string[] children)
        {
            var accounts = _service.Order.GetAll(children);

            return accounts;
        }

        //[HttpGet("[action]")]
        //public IEnumerable<Account> GetAllAccount([FromQuery] int deleteFlag)
        //{
        //    var accounts = _service.Account.GetAll(a => a.DeleteFlag == deleteFlag);

        //    return accounts;
        //}

        [HttpGet("[action]")]
        public bool CheckOrderExist(Order order, string Id)
        {
            var orders = _orderService.CheckOrderExist(order, Id);

            return orders;
        }

        [HttpGet("[action]")]
        public List<Order> GetOrderByCustomerID(string id)
        {
            var order = _orderService.GetOrderByCustomerID(id);

            return order;
        }

        [HttpGet("[action]")]
        public List<Order> GetOrderByHostID(string id)
        {
            var order = _orderService.GetOrderByHostID(id);

            return order;
        }

        [HttpGet("[action]")]
        public Order GetOrderByOrderID(Guid id)
        {
            var order = _orderService.GetOrderByOrderID(id);
            return order;
        }

        [HttpPut("[action]")]
        public void InsertAccount(Order order)
        {
            _service.Order.Insert(order);
        }

        [HttpPut("[action]")]
        public void UpdateOrder(Order order)
        {
            _service.Order.Update(order);
        }

        [HttpDelete("[action]")]
        public void DeleteOrder(Guid id)
        {

            _orderService.Remove(id);
        }
    }
}
