﻿using System;
using SignalR.DTOLayer.DiscountDto;

namespace SignalR.DTOLayer.ProductDto
{
	public class GetProductDto
	{
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}

