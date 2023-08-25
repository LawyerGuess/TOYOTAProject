using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using TOYOTA.Busines.CustomExceptions;
using TOYOTA.Busines.Interfaces;
using TOYOTA.DataAccess.Interfaces;
using TOYOTA.Model.Dtos.Customer;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Implementations
{
    public class CustomerBs : ICustomerBs
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public CustomerBs(ICustomerRepository repo, IMapper mapper)
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

        public async Task<ApiResponse<CustomerGetDto>> GetByIdAsync(int customerId, params string[] includeList)
        {
            if (customerId <= 0)
                throw new BadRequestException("Id value must be greater than 0.");

            var customer = await _repo.GetByIdAsync(customerId, includeList);

            if (customer == null)
                throw new NotFoundException("No content found with this id value.");

            var dto = _mapper.Map<CustomerGetDto>(customer);

            return ApiResponse<CustomerGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetCustomersAsync(params string[] includeList)
        {
            var customers = await _repo.GetAllAsync(includeList: includeList);
            if (customers.Count > 0)
            {
                var returnList = _mapper.Map<List<CustomerGetDto>>(customers);

                return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetCustomersByCityAsync(string city, params string[] includeList)
        {
            var customers = await _repo.GetByCityAsync(city, includeList);
            if (customers != null)
            {
                var returnList = _mapper.Map<List<CustomerGetDto>>(customers);

                return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetCustomersByFirstNameAsync(string firstname, params string[] includeList)
        {
            var customers = await _repo.GetByFirstNameAsync(firstname, includeList);
            if (customers != null)
            {
                var returnList = _mapper.Map<List<CustomerGetDto>>(customers);

                return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetCustomersByLastNameAsync(string lastname, params string[] includeList)
        {
            var customers = await _repo.GetByLastNameAsync(lastname, includeList);
            if (customers != null)
            {
                var returnList = _mapper.Map<List<CustomerGetDto>>(customers);

                return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetCustomersByPhoneNumberAsync(string phonenumber, params string[] includeList)
        {
            var customers = await _repo.GetByPhoneNumberAsync(phonenumber, includeList);
            if (customers != null)
            {
                var returnList = _mapper.Map<List<CustomerGetDto>>(customers);

                return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<Customer>> InsertAsync(CustomerPostDto dto)
        {
            if (dto.FirstName.Length < 2)
                throw new BadRequestException("Content name must be at least 2 characters.");
            if (dto.LastName.Length < 2)
                throw new BadRequestException("Content name must be at least 2 characters.");

            var entity = _mapper.Map<Customer>(dto);
            var insertedCustomer = await _repo.InsertAsync(entity);

            return ApiResponse<Customer>.Success(StatusCodes.Status201Created, insertedCustomer);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CustomerPutDto dto)
        {
            if (dto.CustomerId <= 0)
                throw new BadRequestException("Id value must be greater than 0.");            

            var entity = _mapper.Map<Customer>(dto);
            await _repo.UpdateAsync(entity);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
