using AutoMapper;
using TOYOTA.Model.Dtos.Employee;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Mappers.AutoMapper
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeGetDto>()
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
                dest => dest.Salary,
                opt => opt.MapFrom(src => src.Salary == null
                                ? 0
                                : src.Salary))                
                .ReverseMap();

            CreateMap<EmployeePostDto, Employee>()
                .ForMember(
                dest => dest.Photo,
                opt => opt.MapFrom(src => src.Photo));


                //MapFrom(src => Convert.FromBase64String(src.Base64Photo)));


            CreateMap<EmployeePutDto, Employee>();

        }
    }
}
