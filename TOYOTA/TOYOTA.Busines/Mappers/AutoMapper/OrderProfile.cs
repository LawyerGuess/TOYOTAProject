using AutoMapper;
using TOYOTA.Model.Dtos.Order;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Mappers.AutoMapper
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderGetDto>()
                 .ForMember(
                dest => dest.OrderDate,
                opt => opt.MapFrom(src => src.OrderDate == null
                                ? DateTime.MinValue
                                : src.OrderDate))
                .ForMember(
                dest => dest.ShipDate,
                opt => opt.MapFrom(src => src.ShipDate == null
                                ? DateTime.MinValue
                                : src.ShipDate))
                .ForMember(
                dest => dest.ShipAdress,
                opt => opt.MapFrom(src => src.ShipAdress == null
                                ? " "
                                : src.ShipAdress.ToLower()))
                 .ReverseMap();

            CreateMap<OrderPostDto, Order>();
            CreateMap<OrderPutDto, Order>();
        }
    }
}
