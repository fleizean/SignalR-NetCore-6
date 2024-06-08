using System;
using SignalRWebUI.Dtos.MenuTableDtos;
using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.Dtos.BasketDtos
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

