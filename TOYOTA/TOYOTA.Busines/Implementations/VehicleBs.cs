using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using TOYOTA.Busines.CustomExceptions;
using TOYOTA.Busines.Interfaces;
using TOYOTA.DataAccess.Interfaces;
using TOYOTA.Model.Dtos.Vehicle;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Implementations
{
    public class VehicleBs : IVehicleBs
    {
        private readonly IVehicleRepository _repo;
        private readonly IMapper _mapper;

        public VehicleBs(IVehicleRepository repo, IMapper mapper)
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

        public async Task<ApiResponse<VehicleGetDto>> GetByIdAsync(int vehicleId, params string[] includeList)
        {
            if (vehicleId <= 0)
                throw new BadRequestException("Id value must be greater than 0.");

            var vehicle = await _repo.GetByIdAsync(vehicleId, includeList);

            if (vehicle == null)
                throw new NotFoundException("No content found with this id value.");

            var dto = _mapper.Map<VehicleGetDto>(vehicle);

            return ApiResponse<VehicleGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<VehicleGetDto>>> GetVehiclesAsync(params string[] includeList)
        {
            var vehicles = await _repo.GetAllAsync(includeList: includeList);
            if (vehicles.Count > 0)
            {
                var returnList = _mapper.Map<List<VehicleGetDto>>(vehicles);

                return ApiResponse<List<VehicleGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<VehicleGetDto>>> GetVehiclesByStockAsync(short min, short max, params string[] includeList)
        {
            if (min > max)
                throw new BadRequestException("The minimum value can't be less than the maximum value.");

            if (min < 0 || max < 0)
                throw new BadRequestException("Please enter a positive value.");

            var vehicles = await _repo.GetByStockAsync(min, max, includeList);
            if (vehicles.Count > 0)
            {
                var returnList = _mapper.Map<List<VehicleGetDto>>(vehicles);

                return ApiResponse<List<VehicleGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<VehicleGetDto>>> GetVehiclesByYearAsync(int min, int max, params string[] includeList)
        {
            if (min > max)
                throw new BadRequestException("The minimum value can't be less than the maximum value.");

            if (min < 0 || max < 0)
                throw new BadRequestException("Please enter a positive value.");

            var vehicles = await _repo.GetByYearAsync(min, max, includeList);
            if (vehicles.Count > 0)
            {
                var returnList = _mapper.Map<List<VehicleGetDto>>(vehicles);

                return ApiResponse<List<VehicleGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<Vehicle>> InsertAsync(VehiclePostDto dto)
        {
            if (dto.VehicleName.Length < 7)
                throw new BadRequestException("Content name must be at least 7 characters.");

            if (dto.Year <= 1950 || dto.Year > 2050)
                throw new BadRequestException("Vehicle model date cannot be less than 1950 or more than 2050.");

            var entity = _mapper.Map<Vehicle>(dto);
            var insertedVehicle = await _repo.InsertAsync(entity);

            return ApiResponse<Vehicle>.Success(StatusCodes.Status201Created, insertedVehicle);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(VehiclePutDto dto)
        {
            if (dto.VehicleId <= 0)
                throw new BadRequestException("Id value must be greater than 0.");

            if (dto.VehicleName.Length < 7)
                throw new BadRequestException("Content name must be at least 7 characters.");

            if (dto.Year <= 1950 || dto.Year > 2050)
                throw new BadRequestException("Vehicle model date cannot be less than 1950 or more than 2050.");

            var entity = _mapper.Map<Vehicle>(dto);
            await _repo.UpdateAsync(entity);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }

}
