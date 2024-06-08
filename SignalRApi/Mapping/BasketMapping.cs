using System;
using AutoMapper;
using SignalR.DTOLayer.BasketDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class BasketMapping:Profile
	{
		public BasketMapping()
		{
            CreateMap<Basket, ResultBasketDto>().ReverseMap();
            CreateMap<Basket, CreateBasketDto>().ReverseMap();
            CreateMap<Basket, GetBasketDto>().ReverseMap();
            CreateMap<Basket, UpdateBasketDto>().ReverseMap();
            CreateMap<Basket, ResultBasketWithProductDto>().ReverseMap();
        }
	}
}

