using System;
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
    }
}

