using Infrastructure.DataAccess;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<List<Order>> GetByShipDateAsync(DateTime shipdate, params string[] includeList);
        Task<List<Order>> GetByShipAdressAsync(string shipadress, params string[] includeList);

        Task<Order> GetByIdAsync(int orderId, params string[] includeList);

    }
}
