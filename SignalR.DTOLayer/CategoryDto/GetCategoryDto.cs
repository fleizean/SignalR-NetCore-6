﻿using System;
using SignalR.DTOLayer.ProductDto;

namespace SignalR.DTOLayer.CategoryDto
{
	public class GetCategoryDto
	{
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }
    }
}

