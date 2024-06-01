﻿using System;
namespace SignalR.DTOLayer.FooterDto
{
	public class GetFooterDto
	{
        public int FooterID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string OpeningDays { get; set; }
        public string OpeningTimes { get; set; }
        public bool Status { get; set; } 
    }
}

