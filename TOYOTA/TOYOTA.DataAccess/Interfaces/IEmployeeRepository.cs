using Infrastructure.DataAccess;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Interfaces
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        Task<List<Employee>> GetByBirthDateAsync(DateTime dateTime, params string[] includeList);
        Task<List<Employee>> GetByAnnualLeaveAsync(short annualleave, params string[] includeList);
        Task<List<Employee>> GetBySalaryAsync(decimal min, decimal max, params string[] includeList);

        Task<Employee> GetByIdAsync(int employeeId, params string[] includeList);
    }
}
