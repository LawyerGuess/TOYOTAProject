using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using TOYOTA.Busines.CustomExceptions;
using TOYOTA.Busines.Interfaces;
using TOYOTA.DataAccess.Interfaces;
using TOYOTA.Model.Dtos.SparePart;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Implementations
{
    public class SparePartBs : ISparePartBs
    {
        private readonly ISparePartRepository _repo;
        private readonly IMapper _mapper;

        public SparePartBs(ISparePartRepository repo, IMapper mapper)
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

        public async Task<ApiResponse<SparePartGetDto>> GetByIdAsync(int sparepartId, params string[] includeList)
        {
            if (sparepartId <= 0)
                throw new BadRequestException("Id value must be greater than 0.");

            var sparepart = await _repo.GetByIdAsync(sparepartId, includeList);

            if (sparepart == null)
                throw new NotFoundException("No content found with this id value.");

            var dto = _mapper.Map<SparePartGetDto>(sparepart);

            return ApiResponse<SparePartGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<SparePartGetDto>>> GetSparePartsAsync(params string[] includeList)
        {
            var spareparts = await _repo.GetAllAsync(includeList: includeList);
            if (spareparts.Count > 0)
            {
                var returnList = _mapper.Map<List<SparePartGetDto>>(spareparts);

                return ApiResponse<List<SparePartGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<SparePartGetDto>>> GetSparePartsByNameAsync(string name, params string[] includeList)
        {
            var spareparts = await _repo.GetByNameAsync(name, includeList);
            if (spareparts != null)
            {
                var returnList = _mapper.Map<List<SparePartGetDto>>(spareparts);

                return ApiResponse<List<SparePartGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<SparePartGetDto>>> GetSparePartsByStockAsync(short min, short max, params string[] includeList)
        {
            if (min > max)
                throw new BadRequestException("The minimum value can't be less than the maximum value.");

            if (min < 0 || max < 0)
                throw new BadRequestException("Please enter a positive value.");

            var spareparts = await _repo.GetByStockAsync(min, max, includeList);
            if (spareparts.Count > 0)
            {
                var returnList = _mapper.Map<List<SparePartGetDto>>(spareparts);

                return ApiResponse<List<SparePartGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<SparePart>> InsertAsync(SparePartPostDto dto)
        {          
            var entity = _mapper.Map<SparePart>(dto);
            var insertedSparePart = await _repo.InsertAsync(entity);

            return ApiResponse<SparePart>.Success(StatusCodes.Status201Created, insertedSparePart);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(SparePartPutDto dto)
        {
            if (dto.SparePartId <= 0)
                throw new BadRequestException("Id value must be greater than 0.");
            if (dto.Stock < 0)
                throw new BadRequestException("Stock number must be at least 1.");

            var entity = _mapper.Map<SparePart>(dto);
            await _repo.UpdateAsync(entity);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
