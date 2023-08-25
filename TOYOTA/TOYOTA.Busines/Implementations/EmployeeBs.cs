using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using TOYOTA.Busines.CustomExceptions;
using TOYOTA.Busines.Interfaces;
using TOYOTA.DataAccess.Interfaces;
using TOYOTA.Model.Dtos.Employee;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Implementations
{
    public class EmployeeBs : IEmployeeBs
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;

        public EmployeeBs(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("Id value must be greater than 0.");

            var entity = await _repo.GetByIdAsync(id);
            entity.IsActive = false;
            await _repo.UpdateAsync(entity);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<EmployeeGetDto>> GetByIdAsync(int employeeId, params string[] includeList)
        {
            if (employeeId <= 0)
                throw new BadRequestException("Id value must be greater than 0.");

            var employee = await _repo.GetByIdAsync(employeeId, includeList);

            if (employee == null)
                throw new NotFoundException("No content found with this id value.");

            var dto = _mapper.Map<EmployeeGetDto>(employee);

            return ApiResponse<EmployeeGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesAsync(params string[] includeList)
        {
            var employees = await _repo.GetAllAsync(includeList: includeList);
            if (employees.Count > 0)
            {
                var returnList = _mapper.Map<List<EmployeeGetDto>>(employees);

                return ApiResponse<List<EmployeeGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesByAnnualLeaveAsync(short annualleave, params string[] includeList)
        {
            var employees = await _repo.GetByAnnualLeaveAsync(annualleave, includeList);
            if (employees != null)
            {
                var returnList = _mapper.Map<List<EmployeeGetDto>>(employees);

                return ApiResponse<List<EmployeeGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesByBirthDateAsync(DateTime birthdate, params string[] includeList)
        {
            var employees = await _repo.GetByBirthDateAsync(birthdate, includeList);
            if (employees != null)
            {
                var returnList = _mapper.Map<List<EmployeeGetDto>>(employees);

                return ApiResponse<List<EmployeeGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesBySalaryAsync(decimal min, decimal max, params string[] includeList)
        {
            if (min > max)
                throw new BadRequestException("The minimum value can't be less than the maximum value.");
            if (min < 0 || max < 0)
                throw new BadRequestException("Please enter a positive value.");

            var employees = await _repo.GetBySalaryAsync(min, max, includeList);
            if (employees.Count > 0)
            {
                var returnList = _mapper.Map<List<EmployeeGetDto>>(employees);

                return ApiResponse<List<EmployeeGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<Employee>> InsertAsync(EmployeePostDto dto)
        {
            if (dto.FirstName.Length < 2)
                throw new BadRequestException("Content name must be at least 2 characters.");
            if (dto.LastName.Length < 2)
                throw new BadRequestException("Content name must be at least 2 characters.");
            if (dto.Salary <= 10000 || dto.Salary > 50000)
                throw new BadRequestException("Salary amount cannot be less than 1950 or more than 2050.");

            var entity = _mapper.Map<Employee>(dto);
            var insertedEmployee = await _repo.InsertAsync(entity);

            return ApiResponse<Employee>.Success(StatusCodes.Status201Created, insertedEmployee);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(EmployeePutDto dto)
        {
            if (dto.EmployeeId <= 0)
                throw new BadRequestException("Id value must be greater than 0.");
           
            var entity = _mapper.Map<Employee>(dto);
            await _repo.UpdateAsync(entity);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
