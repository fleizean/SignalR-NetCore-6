using System;
using SignalR.DTOLayer.OrderDetailDto;

namespace SignalR.DTOLayer.OrderDto
{
	public class CreateOrderDto
	{
		public string? TableNumber { get; set; }
		public string? Description { get; set; }
		public DateTime Date { get; set; }
		public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
	}
}

