using AutoMapper;
using TOYOTA.Model.Dtos.Category;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Mappers.AutoMapper
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryGetDto>()
                .ForMember(
                dest => dest.VehicleName,
                opt => opt.MapFrom(src => src.Vehicle.VehicleName))

                .ForMember(
                dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.CategoryName == null
                                ? " "
                                : src.CategoryName.ToUpper()))
                .ForMember(
                dest => dest.Pack,
                opt => opt.MapFrom(src => src.Pack == null
                                ? " "
                                : src.Pack.ToLower()))
                .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description == null
                                ? " "
                                : src.Description.ToLower()))
                .ForMember(
                dest => dest.VehicleEngine,
                opt => opt.MapFrom(src => src.VehicleEngine == null
                                ? 0
                                : src.VehicleEngine))
                .ForMember(
                dest => dest.UnitPrice,
                opt => opt.MapFrom(src => src.UnitPrice == null
                                ? 0
                                : src.UnitPrice.Value * 1.18m))
                .ReverseMap();

            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryPutDto, Category>();
        }
    }
}
