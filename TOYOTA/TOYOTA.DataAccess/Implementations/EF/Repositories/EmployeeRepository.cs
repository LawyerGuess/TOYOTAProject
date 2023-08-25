using Infrastructure.DataAccess.EF;
using TOYOTA.DataAccess.Implementations.EF.Contexts;
using TOYOTA.DataAccess.Interfaces;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Implementations.EF.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, ToyotaContext>,
        IEmployeeRepository
    {
        public async Task<List<Employee>> GetByAnnualLeaveAsync(short annualleave, params string[] includeList)
        {
            return await GetAllAsync(e => e.AnnualLeave == annualleave, includeList);
        }

        public async Task<List<Employee>> GetByBirthDateAsync(DateTime birthdate, params string[] includeList)
        {
            return await GetAllAsync(e => e.BirthDate == birthdate, includeList);
        }

        public async Task<Employee> GetByIdAsync(int employeeId, params string[] includeList)
        {
            return await GetAsync(e=> e.EmployeeId==employeeId, includeList);
        }

        public async Task<List<Employee>> GetBySalaryAsync(decimal min, decimal max, params string[] includeList)
        {
            return await GetAllAsync(e => e.Salary > min && e.Salary < max, includeList);
        }
    }
}
