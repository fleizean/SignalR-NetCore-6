using System;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IOrderService : IGenericService<Order>
	{
        public List<Order> TGetOrdersWithDetails();
        public decimal TLastOrderPrice();
        public int TTotalActiveOrderCount();
        public int TTotalOrderCount();
        public decimal TTodayTotalPrice();
    }
}

