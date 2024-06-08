using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR.EntityLayer.Entities
{
	public class Basket
	{
		public int BasketID { get; set; }
		public int ProductID { get; set; }
		public int MenuTableID { get; set; }
		public decimal Price { get; set; }
		public int Count { get; set; }
		public decimal TotalPrice { get; set; }
		public bool Status { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        [ForeignKey("MenuTableID")]
        public MenuTable MenuTable { get; set; }
    }
}

