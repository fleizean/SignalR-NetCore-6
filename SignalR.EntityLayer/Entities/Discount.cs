using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR.EntityLayer.Entities
{
	public class Discount
	{
		public int DiscountID { get; set; }
		public int Amount { get; set; }
		public int ProductID { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public bool Status { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }
    }
}

