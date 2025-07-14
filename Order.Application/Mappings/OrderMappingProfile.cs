using AutoMapper;
using Order.Application.Commands.CreateCommand;
using Order.Application.DTOs;
using Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Mappings
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<CreateOrderCommand, OrderModel>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<OrderItemRequest, OrderItem>();
            CreateMap<OrderModel, OrderDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
