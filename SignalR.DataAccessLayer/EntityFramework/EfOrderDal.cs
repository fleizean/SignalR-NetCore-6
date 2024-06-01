using System;
using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public List<Order> GetOrdersWithDetails()
        {
            using var context = new SignalRContext();
            return context.Orders.Include(o => o.OrderDetail).ToList();
        }

        public decimal LastOrderPrice()
        {
            using var context = new SignalRContext();
            var lastOrder = context.Orders.OrderByDescending(o => o.Date).FirstOrDefault();
            return lastOrder?.TotalPrice ?? 0;
        }

        public int TotalActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count(a => a.Status == true);
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();
        }
        public decimal TodayTotalPrice()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(o => o.Date == DateTime.Today).Sum(o => o.TotalPrice);
        }
    }
}

