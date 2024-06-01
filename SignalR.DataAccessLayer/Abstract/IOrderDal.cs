using System;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IOrderDal : IGenericDal<Order>
    {
		List<Order> GetOrdersWithDetails();
        int TotalOrderCount();
		int TotalActiveOrderCount();
		decimal LastOrderPrice();
		decimal TodayTotalPrice();
	}
}

