using Infrastructure.DataAccess;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Interfaces
{
    public interface IAdminPanelUserRepository:IBaseRepository<AdminPanelUser>
    {
        Task<AdminPanelUser> GetByUserNameAndPasswordAsync(string userName, string password, 
            params string[] includeList);
        
    }
}
