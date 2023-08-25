using AutoMapper;
using TOYOTA.Model.Dtos.Customer;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Mappers.AutoMapper
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerGetDto>()
                .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName == null
                                ? " "
                                : src.FirstName.ToLower()))
                .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName == null
                                ? " "
                                : src.LastName.ToUpper()))
                .ForMember(
                dest => dest.PhoneNumber,
                opt => opt.MapFrom(src => src.PhoneNumber == null
                                ? " "
                                : src.PhoneNumber))
                 .ReverseMap();

            CreateMap<CustomerPostDto, Customer>();
            CreateMap<CustomerPutDto, Customer>();

        }
    }
}
