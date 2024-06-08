using System;
using SignalR.DTOLayer.MenuTableDto;
using SignalR.DTOLayer.ProductDto;

namespace SignalR.DTOLayer.BasketDto
{
	public class ResultBasketWithProductDto
	{
        public int BasketID { get; set; }
        public ResultProductDto Product { get; set; }
        public ResultMenuTableDto MenuTable { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
    }
}

