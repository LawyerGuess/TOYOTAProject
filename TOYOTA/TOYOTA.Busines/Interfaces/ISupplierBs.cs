using Infrastructure.Utilities.ApiResponses;
using TOYOTA.Model.Dtos.Supplier;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Interfaces
{
    public interface ISupplierBs
    {
        Task<ApiResponse<List<SupplierGetDto>>> GetSuppliersAsync(params string[] includeList);
        Task<ApiResponse<List<SupplierGetDto>>> GetSuppliersByAdressAsync(string adress, params string[] includeList);
        Task<ApiResponse<List<SupplierGetDto>>> GetSuppliersByCityAndCountryAsync(string city, string country, params string[] includeList);
        Task<ApiResponse<List<SupplierGetDto>>> GetSuppliersByContactPersonAsync(string contactperson, params string[] includeList);

        Task<ApiResponse<SupplierGetDto>> GetByIdAsync(int supplierId, params string[] includeList);
        Task<ApiResponse<Supplier>> InsertAsync(SupplierPostDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<NoData>> UpdateAsync(SupplierPutDto dto);
    }
}
