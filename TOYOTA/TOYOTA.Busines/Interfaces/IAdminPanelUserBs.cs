using Infrastructure.Utilities.ApiResponses;
using TOYOTA.Model.Dtos.AdminPanelUser;

namespace TOYOTA.Busines.Interfaces
{
    public interface IAdminPanelUserBs
    {
        Task<ApiResponse<AdminPanelUserGetDto>> LogInAsync(string userName, string password, 
            params string[] includeList);
    }
}
