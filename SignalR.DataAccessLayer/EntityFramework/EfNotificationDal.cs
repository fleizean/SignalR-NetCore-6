using System;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalRContext context) : base(context)
        {
        }

        public int NotificationCountByStatusFalse()
        {
            using var context = new SignalRContext();
            return context.Notifications.Count(a => a.Status == false);
        }

        public void NotificationStatusFalse(int id)
        {
            using var context = new SignalRContext();
            var notf = context.Notifications.Where(a => a.NotificationID == id).FirstOrDefault();
            notf.Status = false;
            context.SaveChanges();
        }

        public void NotificationStatusTrue(int id)
        {
            using var context = new SignalRContext();
            var notf = context.Notifications.Where(a => a.NotificationID == id).FirstOrDefault();
            notf.Status = true;
            context.SaveChanges();
        }
    }
}

