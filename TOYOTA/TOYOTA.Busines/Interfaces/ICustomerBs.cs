using Infrastructure.Utilities.ApiResponses;
using TOYOTA.Model.Dtos.Customer;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Interfaces
{
    public interface ICustomerBs
    {
        Task<ApiResponse<List<CustomerGetDto>>> GetCustomersAsync( params string[] includeList);
        Task<ApiResponse<List<CustomerGetDto>>> GetCustomersByCityAsync(string city, params string[] includeList);
        Task<ApiResponse<List<CustomerGetDto>>> GetCustomersByFirstNameAsync(string firstname, params string[] includeList);
        Task<ApiResponse<List<CustomerGetDto>>> GetCustomersByLastNameAsync(string lastname, params string[] includeList);
        Task<ApiResponse<List<CustomerGetDto>>> GetCustomersByPhoneNumberAsync(string phonenumber, params string[] includeList);

        Task<ApiResponse<CustomerGetDto>> GetByIdAsync(int customerId, params string[] includeList);
        Task<ApiResponse<Customer>> InsertAsync(CustomerPostDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<NoData>> UpdateAsync(CustomerPutDto dto);
    }
}
