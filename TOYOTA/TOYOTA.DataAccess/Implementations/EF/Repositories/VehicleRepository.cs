using Infrastructure.DataAccess.EF;
using TOYOTA.DataAccess.Implementations.EF.Contexts;
using TOYOTA.DataAccess.Interfaces;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Implementations.EF.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle, ToyotaContext>,
        IVehicleRepository
    {
        public async Task<List<Vehicle>> GetByCategoryAsync(int categoryId, params string[] includeList)
        {
            return await GetAllAsync(v => v.CategoryId == categoryId, includeList);
        }

        public async Task<Vehicle> GetByIdAsync(int vehicleId, params string[] includeList)
        {
            return await GetAsync(v => v.VehicleId == vehicleId, includeList);
        }

        public async Task<List<Vehicle>> GetByStockAsync(short min, short max, params string[] includeList)
        {
            return await GetAllAsync(v => v.UnitsInStock > min && v.UnitsInStock < max, includeList);
        }

        public async Task<List<Vehicle>> GetByYearAsync(int min, int max, params string[] includeList)
        {
            return await GetAllAsync(v => v.Year > min && v.Year < max, includeList);
        }
    }
}
