using System;
using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.Dtos.DiscountDtos
{
	public class ResultDiscountDto
	{
        public int DiscountID { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public ResultProductDto Product { get; set; }
    }
}

