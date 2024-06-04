using System;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IMoneyCaseHistoryDal : IGenericDal<MoneyCaseHistory>
    {
		List<MoneyCaseHistory> MoneyCaseHistories();
	}
}

