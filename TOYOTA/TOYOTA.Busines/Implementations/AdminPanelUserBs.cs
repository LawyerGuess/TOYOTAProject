using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using TOYOTA.Busines.CustomExceptions;
using TOYOTA.Busines.Interfaces;
using TOYOTA.DataAccess.Interfaces;
using TOYOTA.Model.Dtos.AdminPanelUser;

namespace TOYOTA.Busines.Implementations
{
    public class AdminPanelUserBs : IAdminPanelUserBs
    {
        private readonly IAdminPanelUserRepository _repo;
        private readonly IMapper _mapper;

        public AdminPanelUserBs(IAdminPanelUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<AdminPanelUserGetDto>> LogInAsync(string userName, string password,
            params string[] includeList)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new BadRequestException("Username cannot be blank!");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new BadRequestException("Please enter your password!");
            }

            if (userName.Length<=2)
            {
                throw new BadRequestException("Username must be at least 3 characters.");
            }

            var adminUser = await _repo.GetByUserNameAndPasswordAsync(userName, password, includeList);

            if (adminUser == null)
            {
                throw new BadRequestException("User not found!");
            }
            var dto= _mapper.Map<AdminPanelUserGetDto>(adminUser);

            return ApiResponse<AdminPanelUserGetDto>.Success(StatusCodes.Status200OK, dto);
        }
    }
}
