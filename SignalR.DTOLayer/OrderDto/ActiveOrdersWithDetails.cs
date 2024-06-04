using System;
using SignalR.DTOLayer.ProductDto;

namespace SignalR.DTOLayer.OrderDto
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

