using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR.EntityLayer.Entities
{
	public class Order
	{
        [Key]
        public int OrderID { get; set; }
		public int MenuTableID { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public decimal TotalPrice { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
        public bool Status { get; set; }
        [ForeignKey("MenuTableID")]
        public MenuTable MenuTable { get; set; }
    }
}

