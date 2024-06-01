using System;
using AutoMapper;
using SignalR.DTOLayer.OrderDetailDto;
using SignalR.DTOLayer.OrderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, ResultOrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, GetOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            CreateMap<Order, ResultOrderWithDetail>()
                .ForMember(dest => dest.ResultOrderDetailDto, opt => opt.MapFrom(src => src.OrderDetail))
                .ReverseMap();

            CreateMap<OrderDetail, ResultOrderDetailDto>().ReverseMap();
        }
    }
}

