using System;
namespace SignalR.DTOLayer.TestimonialDto
{
	public class GetTestimonialDto
	{
        public int TestimonialID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } // 5 üzerinden ?
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}

