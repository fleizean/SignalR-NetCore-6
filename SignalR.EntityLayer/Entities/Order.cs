using System;
using System.ComponentModel.DataAnnotations;

namespace SignalR.EntityLayer.Entities
{
	public class Order
	{
        [Key]
        public int OrderID { get; set; }
		public string TableNumber { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public decimal TotalPrice { get; set; }
		public bool Status { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}

