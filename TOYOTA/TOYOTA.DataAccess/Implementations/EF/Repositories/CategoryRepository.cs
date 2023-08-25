using Infrastructure.DataAccess.EF;
using TOYOTA.DataAccess.Implementations.EF.Contexts;
using TOYOTA.DataAccess.Interfaces;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Implementations.EF.Repositories
{
    public class CategoryRepository : BaseRepository<Category, ToyotaContext>,
        ICategoryRepository
    {
        public async Task<List<Category>> GetByDescAsync(string desc, params string[] includeList)
        {
            return await GetAllAsync(c => c.Description == desc, includeList);
        }

        public async Task<Category> GetByIdAsync(int categoryId, params string[] includeList)
        { 
            return await GetAsync(c=> c.CategoryId == categoryId, includeList);
        }

        public async Task<List<Category>> GetByPackAsync(string pack, params string[] includeList)
        {
            return await GetAllAsync(c => c.Pack == pack, includeList);
        }

        public async Task<List<Category>> GetByPriceAsync(decimal min, decimal max, params string[] includeList)
        {
            return await GetAllAsync(c => c.UnitPrice > min && c.UnitPrice < max, includeList);
        }
    }
}
