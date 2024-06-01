using System;
using System.ComponentModel.DataAnnotations;

namespace SignalR.EntityLayer.Entities
{
	public class Contact
	{
        [Key]
        public int ContactID { get; set; }
		public string Location { get; set; }
		public string Telephone { get; set; }
		public string Mail { get; set; }
		public bool Status { get; set; }
	}
}

