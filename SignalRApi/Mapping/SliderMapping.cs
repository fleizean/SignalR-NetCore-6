using System;
using AutoMapper;
using SignalR.DTOLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class SliderMapping: Profile
    {
		public SliderMapping()
		{
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, GetSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();
        }
	}
}

