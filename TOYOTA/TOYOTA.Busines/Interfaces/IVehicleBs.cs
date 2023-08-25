using Infrastructure.Utilities.ApiResponses;
using TOYOTA.Model.Dtos.Vehicle;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Interfaces
{
    public interface IVehicleBs
    {
        Task<ApiResponse<List<VehicleGetDto>>> GetVehiclesAsync(params string[] includeList);
        Task<ApiResponse<List<VehicleGetDto>>> GetVehiclesByStockAsync(short min, short max, params string[] includeList);
        Task<ApiResponse<List<VehicleGetDto>>> GetVehiclesByYearAsync(int min, int max, params string[] includeList);

        Task<ApiResponse<VehicleGetDto>> GetByIdAsync(int vehicleId, params string[] includeList);
        Task<ApiResponse<Vehicle>> InsertAsync(VehiclePostDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<NoData>> UpdateAsync(VehiclePutDto dto);


    }
}
