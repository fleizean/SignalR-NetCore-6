using System;
namespace SignalR.EntityLayer.Entities
{
	public class MenuTable
	{
		public int MenuTableID { get; set; }
		public string Name { get; set; }
		public bool Status { get; set; }

        public ICollection<Order> Order { get; set; }
        public ICollection<Basket> Basket { get; set; }

    }
}

