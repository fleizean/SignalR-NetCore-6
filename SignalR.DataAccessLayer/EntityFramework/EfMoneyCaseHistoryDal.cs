using System;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfMoneyCaseHistoryDal : GenericRepository<MoneyCaseHistory>, IMoneyCaseHistoryDal
    {
        public EfMoneyCaseHistoryDal(SignalRContext context) : base(context)
        {
        }

        public List<MoneyCaseHistory> MoneyCaseHistories()
        {
            using var context = new SignalRContext();
            return context.MoneyCaseHistories.OrderByDescending(mch => mch.TransactionDate)
                                    .Take(10)
                                    .ToList();
        }
    }
}

