﻿using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {
        private BirthdayPartyBookingContext _context;
        public OrderRepo(BirthdayPartyBookingContext context)
            : base(context)
        {
            _context = context;
        }
        
        public List<Order> GetOrderByHostID(string id)
        {
            List<Order> orders;
            try
            {
                orders =  _context.Orders.AsNoTracking().Where(o => o.HostId.ToString() == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
        public List<Order> GetOrderByCustomerID(string id)
        {
            List<Order> orders;
            try
            {
                orders =  _context.Orders.AsNoTracking().Where(o => o.GuestId.ToString() == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
        public Order GetOrderByOrderID(Guid id)
        {
            Order orders;
            try
            {
                orders =  _context.Orders.AsNoTracking().FirstOrDefault(m => m.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public bool CheckOrderExist(Order order, string Id)
        {
            bool check = false;
            try
            {
                check = _context.Orders.AsNoTracking().Any(o => o.Date == order.Date && o.HostId.ToString() == Id && o.PlaceId == order.PlaceId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return check;
        }
        #region Optional
        //public void AddNew(Order order)
        //{
        //    try
        //    {
        //        _context.Orders.Add(order);
        //        _context.SaveChanges();
        //        _context.Entry(order).State = EntityState.Detached;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        //public async Task Update(Order order)
        //{
        //    try
        //    {
        //        Task<Order> _order = GetOrderByOrderID(order.Id);
        //        if (_order != null)
        //        {
        //            _context.Entry<Order>(order).State = EntityState.Modified;
        //            await _context.SaveChangesAsync();
        //            _context.Entry(order).State = EntityState.Detached;
        //        }
        //        else
        //        {
        //            throw new Exception("The order not found.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        #endregion
        public void Remove(Guid Id)
        {
            try
            {
                Order _order = GetOrderByOrderID(Id);
                if (_order != null)
                {
                    _order.DeleteFlag = 1;
                    _context.Entry<Order>(_order).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}