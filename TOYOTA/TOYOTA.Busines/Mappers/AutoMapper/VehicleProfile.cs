using AutoMapper;
using TOYOTA.Model.Dtos.Vehicle;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Mappers.AutoMapper
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleGetDto>()
                .ForMember(
                dest => dest.VehicleName,
                opt => opt.MapFrom(src => src.VehicleName == null
                                ? " "
                                : src.VehicleName.ToUpper()))
                .ForMember(
                dest => dest.Year,
                opt => opt.MapFrom(src => src.Year == null
                                ? 0
                                : src.Year))
                .ForMember(
                dest => dest.Color,
                opt => opt.MapFrom(src => src.Color == null
                                ? " "
                                : src.Color))                
                .ReverseMap();

            CreateMap<VehiclePostDto, Vehicle>();
            CreateMap<VehiclePutDto, Vehicle>();
        }
    }
}
