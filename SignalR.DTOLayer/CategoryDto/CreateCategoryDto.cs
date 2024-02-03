using System;
using SignalR.DTOLayer.ProductDto;

namespace SignalR.DTOLayer.CategoryDto
{
	public class CreateCategoryDto
	{
        public string CategoryName { get; set; }
        public bool Status { get; set; }
    }
}

