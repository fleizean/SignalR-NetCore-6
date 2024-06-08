using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SignalR.EntityLayer.Entities
{
	public class Product
	{
        [Key]
        public int ProductID { get; set; }
		public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public bool Status { get; set; }

        [ForeignKey("CategoryID")]
		public Category Category { get; set; }

        public ICollection<Discount> Discounts { get; set; }
        public ICollection<Basket> Baskets { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }

    }
}

