using AutoMapper;
using TOYOTA.Model.Dtos.Supplier;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Mappers.AutoMapper
{
    public class SupplierProfile:Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierGetDto>()
                .ForMember(
                dest => dest.CompanyName,
                opt => opt.MapFrom(src => src.CompanyName == null
                                ? " "
                                : src.CompanyName.ToUpper()))
                .ForMember(
                dest => dest.ContactPerson,
                opt => opt.MapFrom(src => src.ContactPerson == null
                                ? " "
                                : src.ContactPerson.ToLower()))
                .ForMember(
                dest => dest.Phone,
                opt => opt.MapFrom(src => src.Phone == null
                                ? 0
                                : src.Phone))
                .ReverseMap();

            CreateMap<SupplierPostDto, Supplier>();
            CreateMap<SupplierPutDto, Supplier>();

        }
    }
}
