using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using TOYOTA.Busines.CustomExceptions;
using TOYOTA.Busines.Interfaces;
using TOYOTA.DataAccess.Interfaces;
using TOYOTA.Model.Dtos.Category;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Implementations
{
    public class CategoryBs : ICategoryBs
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryBs(ICategoryRepository repo, IMapper mapper)
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

        public async Task<ApiResponse<CategoryGetDto>> GetByIdAsync(int categoryId, params string[] includeList)
        {
            if (categoryId <= 0)
                throw new BadRequestException("Id value must be greater than 0.");

            var category = await _repo.GetByIdAsync(categoryId, includeList);

            if (category == null)
                throw new NotFoundException("No content found with this id value.");

            var dto = _mapper.Map<CategoryGetDto>(category);

            return ApiResponse<CategoryGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesAsync(params string[] includeList)
        {
            var categories = await _repo.GetAllAsync(includeList: includeList);
            if (categories.Count > 0)
            {
                var returnList = _mapper.Map<List<CategoryGetDto>>(categories);

                return ApiResponse<List<CategoryGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesByDescAsync(string desc, params string[] includeList)
        {
            var categories = await _repo.GetByDescAsync(desc, includeList);
            if (categories != null)
            {
                var returnList = _mapper.Map<List<CategoryGetDto>>(categories);

                return ApiResponse<List<CategoryGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesByPackAsync(string pack, params string[] includeList)
        {
            var categories = await _repo.GetByPackAsync(pack, includeList);
            if (categories != null)
            {
                var returnList = _mapper.Map<List<CategoryGetDto>>(categories);

                return ApiResponse<List<CategoryGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesByPriceAsync(decimal min, decimal max, params string[] includeList)
        {
            if (min > max)
                throw new BadRequestException("The minimum value can't be less than the maximum value.");
            if (min < 0 || max < 0)
                throw new BadRequestException("Please enter a positive value.");

            var categories = await _repo.GetByPriceAsync(min, max, includeList);
            if (categories.Count > 0)
            {
                var returnList = _mapper.Map<List<CategoryGetDto>>(categories);

                return ApiResponse<List<CategoryGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<Category>> InsertAsync(CategoryPostDto dto)
        {
            if (dto.CategoryName.Length < 5)
                throw new BadRequestException("Content name must be at least 5 characters.");

            if (dto.UnitPrice <= 100000 || dto.UnitPrice > 10000000)
                throw new BadRequestException("Vehicle price cannot be less than 100000 or more than 10000000.");

            var entity = _mapper.Map<Category>(dto);
            var insertedCategory = await _repo.InsertAsync(entity);

            return ApiResponse<Category>.Success(StatusCodes.Status201Created, insertedCategory);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CategoryPutDto dto)
        {
            if (dto.CategoryId <= 0)
                throw new BadRequestException("Id value must be greater than 0.");
            if (dto.Description.Length < 7)
                throw new BadRequestException("Content name must be at least 7 characters.");

            var entity = _mapper.Map<Category>(dto);
            await _repo.UpdateAsync(entity);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
