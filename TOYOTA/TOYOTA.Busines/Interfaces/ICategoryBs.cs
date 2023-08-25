using Infrastructure.Utilities.ApiResponses;
using TOYOTA.Model.Dtos.Category;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Interfaces
{
    public interface ICategoryBs
    {
        Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesAsync(params string[] includeList);
        Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesByDescAsync(string desc, params string[] includeList);
        Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesByPackAsync(string pack, params string[] includeList);
        Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesByPriceAsync(decimal min, decimal max, params string[] includeList);


        Task<ApiResponse<CategoryGetDto>> GetByIdAsync(int categoryId, params string[] includeList);
        Task<ApiResponse<Category>> InsertAsync(CategoryPostDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<NoData>> UpdateAsync(CategoryPutDto dto);
    }
}
