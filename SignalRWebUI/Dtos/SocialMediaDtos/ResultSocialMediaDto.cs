﻿using System;
namespace SignalRWebUI.Dtos.SocialMediaDtos
{
	public class ResultSocialMediaDto
	{
        public int SocialMediaID { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public bool Status { get; set; }
    }
}

