﻿using System;
using SignalR.DTOLayer.ProductDto;

namespace SignalR.DTOLayer.DiscountDto
{
	public class ResultDiscountWithProduct
	{
        public int DiscountID { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public ResultProductDto Product { get; set; }
    }
}

