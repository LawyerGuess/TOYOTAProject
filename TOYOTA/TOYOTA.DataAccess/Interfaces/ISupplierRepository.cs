using Infrastructure.DataAccess;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Interfaces
{
    public interface ISupplierRepository : IBaseRepository<Supplier>
    {
        Task<List<Supplier>> GetByContactPersonAsync(string contactperson, params string[] includeList);
        Task<List<Supplier>> GetByAdressAsync(string adress, params string[] includeList);
        Task<List<Supplier>> GetByCityAndCountryAsync(string city, string counry, params string[] includeList);

        Task<Supplier> GetByIdAsync(int supplierId, params string[] includeList);
    }
}
