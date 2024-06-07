using System;
using SignalRWebUI.Dtos.CategoryDtos;

namespace SignalRWebUI.Dtos.ProductDtos
{
	public class ResultProductWithCategory
	{
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public ResultCategoryDto Category { get; set; }

    }
}

