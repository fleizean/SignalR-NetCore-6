using System;
namespace SignalR.DTOLayer.BasketDto
{
	public class CreateBasketDto
	{
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
    }
}

