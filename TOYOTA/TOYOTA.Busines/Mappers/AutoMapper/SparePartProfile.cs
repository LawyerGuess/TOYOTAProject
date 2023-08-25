using AutoMapper;
using TOYOTA.Model.Dtos.SparePart;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Mappers.AutoMapper
{
    public class SparePartProfile:Profile 
    {
        public SparePartProfile()
        {
            CreateMap<SparePart, SparePartGetDto>()
               .ForMember(
               dest => dest.Name,
               opt => opt.MapFrom(src => src.Name == null
                               ? " "
                               : src.Name.ToLower()))
               .ForMember(
               dest => dest.Category,
               opt => opt.MapFrom(src => src.Category == null
                               ? " "
                               : src.Category.ToLower()))
                .ReverseMap();

            CreateMap<SparePartPostDto, SparePart>();
            CreateMap<SparePartPutDto, SparePart>();

        }
    }
}
