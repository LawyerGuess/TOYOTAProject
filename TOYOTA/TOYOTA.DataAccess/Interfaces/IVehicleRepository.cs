using Infrastructure.DataAccess;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Interfaces
{
    public interface IVehicleRepository : IBaseRepository<Vehicle>
    {
        Task<List<Vehicle>> GetByStockAsync(short min, short max, params string[] includeList);
        Task<List<Vehicle>> GetByYearAsync(int min, int max, params string[] includeList);
        Task<List<Vehicle>> GetByCategoryAsync(int Category, params string[] includeList);

        Task<Vehicle> GetByIdAsync(int vehicleId, params string[] includeList);
    }
}
