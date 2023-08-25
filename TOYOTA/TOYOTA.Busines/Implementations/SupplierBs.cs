using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using TOYOTA.Busines.CustomExceptions;
using TOYOTA.Busines.Interfaces;
using TOYOTA.DataAccess.Interfaces;
using TOYOTA.Model.Dtos.Supplier;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Implementations
{
    public class SupplierBs : ISupplierBs
    {
        private readonly ISupplierRepository _repo;
        private readonly IMapper _mapper;

        public SupplierBs(ISupplierRepository repo, IMapper mapper)
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

        public async Task<ApiResponse<SupplierGetDto>> GetByIdAsync(int supplierId, params string[] includeList)
        {
            if (supplierId <= 0)
                throw new BadRequestException("Id value must be greater than 0.");

            var supplier = await _repo.GetByIdAsync(supplierId, includeList);

            if (supplier == null)
                throw new NotFoundException("No content found with this id value.");

            var dto = _mapper.Map<SupplierGetDto>(supplier);

            return ApiResponse<SupplierGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<SupplierGetDto>>> GetSuppliersAsync(params string[] includeList)
        {
            var suppliers = await _repo.GetAllAsync(includeList: includeList);
            if (suppliers.Count > 0)
            {
                var returnList = _mapper.Map<List<SupplierGetDto>>(suppliers);

                return ApiResponse<List<SupplierGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<SupplierGetDto>>> GetSuppliersByAdressAsync(string adress, params string[] includeList)
        {
            var suppliers = await _repo.GetByAdressAsync(adress, includeList);
            if (suppliers != null)
            {
                var returnList = _mapper.Map<List<SupplierGetDto>>(suppliers);

                return ApiResponse<List<SupplierGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<SupplierGetDto>>> GetSuppliersByCityAndCountryAsync(string city, string country, params string[] includeList)
        {
            var suppliers = await _repo.GetByCityAndCountryAsync(city, country, includeList);
            if (suppliers != null)
            {
                var returnList = _mapper.Map<List<SupplierGetDto>>(suppliers);

                return ApiResponse<List<SupplierGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<SupplierGetDto>>> GetSuppliersByContactPersonAsync(string contactperson, params string[] includeList)
        {
            var suppliers = await _repo.GetByAdressAsync(contactperson, includeList);
            if (suppliers != null)
            {
                var returnList = _mapper.Map<List<SupplierGetDto>>(suppliers);

                return ApiResponse<List<SupplierGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<Supplier>> InsertAsync(SupplierPostDto dto)
        {
            if (dto.Adress.Length < 7)
                throw new BadRequestException("Content name must be at least 7 characters.");
            
            var entity = _mapper.Map<Supplier>(dto);
            var insertedSupplier = await _repo.InsertAsync(entity);

            return ApiResponse<Supplier>.Success(StatusCodes.Status201Created, insertedSupplier);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(SupplierPutDto dto)
        {
            if (dto.SupplierId <= 0)
                throw new BadRequestException("Id value must be greater than 0.");
            if (dto.Adress.Length < 7)
                throw new BadRequestException("Content name must be at least 7 characters.");            

            var entity = _mapper.Map<Supplier>(dto);
            await _repo.UpdateAsync(entity);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
