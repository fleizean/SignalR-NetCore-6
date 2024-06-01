using System;
using System.ComponentModel.DataAnnotations;

namespace SignalR.EntityLayer.Entities
{
	public class Footer
	{
        [Key]
        public int FooterID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public string OpeningDays { get; set; }
		public string OpeningTimes { get; set; }
		public bool Status { get; set; }
	}
}

