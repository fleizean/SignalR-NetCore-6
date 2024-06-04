using System;
using SignalR.DTOLayer.ProductDto;

namespace SignalR.DTOLayer.DiscountDto
{
	public class ResultDiscountWithProduct
	{
        public int DiscountID { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public ResultProductWithCategory Product { get; set; }
    }
}

