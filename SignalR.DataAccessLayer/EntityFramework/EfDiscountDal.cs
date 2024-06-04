using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContext context) : base(context)
        {
        }

        public List<Discount> GetDiscountsWithProducts()
        {
            var context = new SignalRContext();
            return context.Discounts.Include(d => d.Product).ThenInclude(d => d.Category).ToList();
        }

        public string LastDiscountProduct()
        {
            var context = new SignalRContext();
            var lastDiscount = context.Discounts
                           .Include(d => d.Product)
                           .OrderByDescending(d => d.DiscountID)
                           .FirstOrDefault();

            return lastDiscount?.Product?.ProductName ?? "Not found";
        }

        public int MostDiscountAmount()
        {
            var context = new SignalRContext();
            if (context.Discounts.Any())
            {
                return context.Discounts.Max(d => d.Amount);

            }
            return 0;
        }
    }
}

