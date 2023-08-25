using Infrastructure.DataAccess;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<List<Customer>> GetByFirstNameAsync(string firstname, params string[] includeList);
        Task<List<Customer>> GetByLastNameAsync(string lastname, params string[] includeList);
        Task<List<Customer>> GetByPhoneNumberAsync(string phonenumber, params string[] includeList);
        Task<List<Customer>> GetByCityAsync(string city, params string[] includeList);

        Task<Customer> GetByIdAsync(int customerId, params string[] includeList);

    }
}
