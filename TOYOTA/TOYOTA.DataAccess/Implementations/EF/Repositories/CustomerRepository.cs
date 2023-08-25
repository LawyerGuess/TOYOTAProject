using Infrastructure.DataAccess.EF;
using TOYOTA.DataAccess.Implementations.EF.Contexts;
using TOYOTA.DataAccess.Interfaces;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Implementations.EF.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, ToyotaContext>,
        ICustomerRepository
    {
        public async Task<List<Customer>> GetByCityAsync(string city, params string[] includeList)
        {
            return await GetAllAsync(c => c.City == city, includeList);
        }

        public async Task<List<Customer>> GetByFirstNameAsync(string firstname, params string[] includeList)
        {
            return await GetAllAsync(c => c.FirstName == firstname, includeList);
        }

        public async Task<Customer> GetByIdAsync(int customerId, params string[] includeList)
        {
            return await GetAsync(c => c.CustomerId == customerId, includeList);
        }

        public async Task<List<Customer>> GetByLastNameAsync(string lastname, params string[] includeList)
        {
            return await GetAllAsync(c => c.LastName == lastname, includeList);
        }

        public async Task<List<Customer>> GetByPhoneNumberAsync(string phonenumber, params string[] includeList)
        {
            return await GetAllAsync(c => c.PhoneNumber == phonenumber, includeList);
        }
    }
}
