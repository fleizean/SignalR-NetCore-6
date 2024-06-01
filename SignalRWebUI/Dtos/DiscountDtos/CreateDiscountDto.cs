using System;
namespace SignalRWebUI.Dtos.DiscountDtos
{
	public class CreateDiscountDto
	{
        public int ProductID { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}

