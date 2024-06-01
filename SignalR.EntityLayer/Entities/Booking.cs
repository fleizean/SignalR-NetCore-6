﻿using System;
namespace SignalR.EntityLayer.Entities
{
	public class Booking
	{
		public int BookingID { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Mail { get; set; }
		public int PersonCount { get; set; }
		public DateTime ReservationDate { get; set; }
		public bool Status { get; set; }
	}
}

