using Infrastructure.Utilities.ApiResponses;
using TOYOTA.Model.Dtos.Employee;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Interfaces
{
    public interface IEmployeeBs
    {
        Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesAsync(params string[] includeList);
        Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesByAnnualLeaveAsync(short annualleave, params string[] includeList);
        Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesByBirthDateAsync(DateTime birthdate, params string[] includeList);
        Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesBySalaryAsync(decimal min, decimal max, params string[] includeList);

        Task<ApiResponse<EmployeeGetDto>> GetByIdAsync(int employeeId, params string[] includeList);
        Task<ApiResponse<Employee>> InsertAsync(EmployeePostDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<NoData>> UpdateAsync(EmployeePutDto dto);
    }
}
