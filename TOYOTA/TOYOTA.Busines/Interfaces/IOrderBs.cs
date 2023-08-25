using Infrastructure.Utilities.ApiResponses;
using TOYOTA.Model.Dtos.Order;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Interfaces
{
    public interface IOrderBs
    {
        Task<ApiResponse<List<OrderGetDto>>> GetOrdersAsync(params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetOrdersByShipAdressAsync(string shipadress, params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetOrdersByShipDateAsync(DateTime shipdate, params string[] includeList);

        Task<ApiResponse<OrderGetDto>> GetByIdAsync(int orderId, params string[] includeList);
        Task<ApiResponse<Order>> InsertAsync(OrderPostDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<NoData>> UpdateAsync(OrderPutDto dto);
    }
}
