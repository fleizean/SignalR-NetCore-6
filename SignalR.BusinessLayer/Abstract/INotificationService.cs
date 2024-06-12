using System;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
	public interface INotificationService : IGenericService<Notification>
    {
        public int TNotificationCountByStatusFalse();

    }
}

