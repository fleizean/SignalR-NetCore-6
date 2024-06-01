using System;
namespace SignalRWebUI.Dtos.DiscountDtos
{
	public class UpdateDiscountDto
	{
        public int DiscountID { get; set; }
        public int ProductID { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}

