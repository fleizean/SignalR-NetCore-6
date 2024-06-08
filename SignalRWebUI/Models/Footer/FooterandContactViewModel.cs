using System;
using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.Dtos.FooterDtos;
using SignalRWebUI.Dtos.SocialMediaDtos;

namespace SignalRWebUI.Models.Footer
{
	public class FooterandContactViewModel
	{
        public ResultFooterDto Footer { get; set; }
        public ResultContactDto Contact { get; set; }
        public List<ResultSocialMediaDto> SocialMedia { get; set; }
    }
}

