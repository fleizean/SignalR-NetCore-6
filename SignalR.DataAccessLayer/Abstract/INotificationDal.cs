using System;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface INotificationDal : IGenericDal<Notification>
    {
		int NotificationCountByStatusFalse();

		void NotificationStatusFalse(int id);
		void NotificationStatusTrue(int id);
	}
}

