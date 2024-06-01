using System;
using AutoMapper;
using SignalR.DTOLayer.FooterDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class FooterMapping : Profile
    {
        public FooterMapping()
        {
            CreateMap<Footer, ResultFooterDto>().ReverseMap();
            CreateMap<Footer, CreateFooterDto>().ReverseMap();
            CreateMap<Footer, GetFooterDto>().ReverseMap();
            CreateMap<Footer, UpdateFooterDto>().ReverseMap();
        }
    }
}

