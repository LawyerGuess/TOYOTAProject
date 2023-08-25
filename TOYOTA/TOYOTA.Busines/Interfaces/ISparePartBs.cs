using Infrastructure.Utilities.ApiResponses;
using TOYOTA.Model.Dtos.SparePart;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Interfaces
{
    public interface ISparePartBs
    {
        Task<ApiResponse<List<SparePartGetDto>>> GetSparePartsAsync(params string[] includeList);
        Task<ApiResponse<List<SparePartGetDto>>> GetSparePartsByNameAsync(string name, params string[] includeList);
        Task<ApiResponse<List<SparePartGetDto>>> GetSparePartsByStockAsync(short min, short max, params string[] includeList);

        Task<ApiResponse<SparePartGetDto>> GetByIdAsync(int sparepartId, params string[] includeList);
        Task<ApiResponse<SparePart>> InsertAsync(SparePartPostDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<NoData>> UpdateAsync(SparePartPutDto dto);
    }
}
