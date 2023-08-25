using Infrastructure.DataAccess.EF;
using TOYOTA.DataAccess.Implementations.EF.Contexts;
using TOYOTA.DataAccess.Interfaces;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Implementations.EF.Repositories
{
    public class SparePartRepository : BaseRepository<SparePart, ToyotaContext>,
        ISparePartRepository
    {
        public async Task<SparePart> GetByIdAsync(int sparepartId, params string[] includeList)
        {
            return await GetAsync(s => s.SparePartId == sparepartId, includeList);
        }

        public async Task<List<SparePart>> GetByNameAsync(string name, params string[] includeList)
        {
            return await GetAllAsync(sP => sP.Name == name, includeList);
        }

        public async Task<List<SparePart>> GetByStockAsync(short min, short max, params string[] includeList)
        {
            return await GetAllAsync(sP => sP.Stock > min && sP.Stock < max, includeList);
        }
    }
}
