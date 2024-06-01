using System;
using System.ComponentModel.DataAnnotations;

namespace SignalR.EntityLayer.Entities
{
	public class Category
	{
        [Key]
        public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public bool Status { get; set; }

		public ICollection<Product> Products { get; set; }
	}
}

