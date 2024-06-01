using System;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        public EfMoneyCaseDal(SignalRContext context) : base(context)
        {
        }

        public decimal TotalPriceMoneyCase()
        {
            using var context = new SignalRContext();
            var totalPrice = context.MoneyCases.FirstOrDefault();
            return totalPrice?.TotalAmount ?? 0;
        }
    }
}

