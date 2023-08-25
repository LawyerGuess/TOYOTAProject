using Infrastructure.DataAccess.EF;
using System.Xml.Linq;
using TOYOTA.DataAccess.Implementations.EF.Contexts;
using TOYOTA.DataAccess.Interfaces;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Implementations.EF.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier, ToyotaContext>,
        ISupplierRepository
    {
        public async Task<List<Supplier>> GetByAdressAsync(string adress, params string[] includeList)
        {
            return await GetAllAsync(s => s.Adress == adress, includeList);
        }

        public async Task<List<Supplier>> GetByCityAndCountryAsync(string city, string country, params string[] includeList)
        {
            return await GetAllAsync(s => s.City == city && s.Country == country, includeList);
        }

        public async Task<List<Supplier>> GetByContactPersonAsync(string contactperson, params string[] includeList)
        {
            return await GetAllAsync(s => s.ContactPerson == contactperson, includeList);
        }

        public async Task<Supplier> GetByIdAsync(int supplierId, params string[] includeList)
        {
            return await GetAsync(s => s.SupplierId == supplierId, includeList);
        }
    }
}
