using System;
using SignalR.DataAccessLayer.Dtos.Product;

namespace SignalR.DataAccessLayer.Dtos.Order
{
	public class ActiveOrdersWithDetails
	{
        public int OrderID { get; set; }
        public decimal TotalPrice { get; set; }
        public string MenuTableName { get; set; }
        public ResultProductDto Product { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

