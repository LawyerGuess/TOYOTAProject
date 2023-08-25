using AutoMapper;
using TOYOTA.Model.Dtos.AdminPanelUser;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Mappers.AutoMapper
{
    public class AdminUserProfile : Profile
    {
        public AdminUserProfile()
        {
            CreateMap<AdminPanelUser, AdminPanelUserGetDto>();
        }
    }
}
