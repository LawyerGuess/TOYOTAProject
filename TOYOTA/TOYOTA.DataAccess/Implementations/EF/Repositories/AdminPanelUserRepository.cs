using Infrastructure.DataAccess.EF;
using TOYOTA.DataAccess.Implementations.EF.Contexts;
using TOYOTA.DataAccess.Interfaces;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Implementations.EF.Repositories
{
    public class AdminPanelUserRepository : BaseRepository<AdminPanelUser, ToyotaContext>, IAdminPanelUserRepository
    {
        public async Task<AdminPanelUser> GetByUserNameAndPasswordAsync(string userName, string password, 
            params string[] includeList)
        {
            return await GetAsync(x => x.UserName == userName && x.Password == password &&
            x.IsActive.Value, includeList);
        }
    }
}
