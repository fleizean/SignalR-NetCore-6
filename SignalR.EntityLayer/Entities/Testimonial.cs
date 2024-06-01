using System;
using System.ComponentModel.DataAnnotations;

namespace SignalR.EntityLayer.Entities
{
	public class Testimonial
	{
        [Key]
        public int TestimonialID { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
		public string Comment { get; set; }
		public int Rating { get; set; } // 5 üzerinden ?
		public string ImageUrl { get; set; }
		public bool Status { get; set; }
	}
}

