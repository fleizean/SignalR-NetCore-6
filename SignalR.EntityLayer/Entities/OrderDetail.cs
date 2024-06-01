using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR.EntityLayer.Entities
{
	public class OrderDetail
	{
		public int OrderDetailID { get; set; }
		public int ProductID { get; set; }
		public int Count { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal TotalPrice { get; set; }
		public int OrderID { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        [ForeignKey("OrderID")]
        public Order Order { get; set; }
    }
}

