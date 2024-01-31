using System;
using System.ComponentModel.DataAnnotations;

namespace SignalR.EntityLayer.Entities
{
	public class About
	{
        [Key]
        public int AboutID { get; set; }
		public string ImageUrl { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}

