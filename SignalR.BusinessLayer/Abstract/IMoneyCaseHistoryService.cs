using System;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IMoneyCaseHistoryService : IGenericService<MoneyCaseHistory>
    {
        public List<MoneyCaseHistory> TMoneyCaseHistories();

    }
}

