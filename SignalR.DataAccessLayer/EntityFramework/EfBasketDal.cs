using System;
using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context) : base(context)
        {
        }

        public List<Basket> GetBaskeyByMenuTableNumber(int id)
        {
            using var context = new SignalRContext();

            return context.Baskets
                .Include(b => b.MenuTable)
                .Include(b => b.Product)
                .Where(b => b.MenuTableID == id)
                .ToList();
        }
    }
}

