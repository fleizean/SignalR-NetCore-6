using System;
using SignalR.DataAccessLayer.Dtos.Order;
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
		List<ActiveOrdersWithDetails> GetActiveOrdersWithDetails();
	}
}

