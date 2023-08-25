using Infrastructure.DataAccess;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<List<Category>> GetByPriceAsync(decimal min, decimal max, params string[] includeList);
        Task<List<Category>> GetByDescAsync(string desc, params string[] includeList);
        Task<List<Category>> GetByPackAsync(string pack, params string[] includeList);

        Task<Category> GetByIdAsync(int categoryId, params string[] includeList);
        
    }
}
