﻿using System;
namespace SignalR.DTOLayer.Notification
{
	public class CreateNotificationDto
	{
        public string Type { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}

