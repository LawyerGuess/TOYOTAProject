using Infrastructure.DataAccess.EF;
using TOYOTA.DataAccess.Implementations.EF.Contexts;
using TOYOTA.DataAccess.Interfaces;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Implementations.EF.Repositories
{
    public class OrderRepository : BaseRepository<Order, ToyotaContext>,
        IOrderRepository
    {
        public async Task<Order> GetByIdAsync(int orderId, params string[] includeList)
        {
            return await GetAsync(o=> o.OrderId==orderId, includeList);
        }

        public async Task<List<Order>> GetByShipAdressAsync(string shipadress, params string[] includeList)
        {
            return await GetAllAsync(o => o.ShipAdress == shipadress, includeList);
        }

        public async Task<List<Order>> GetByShipDateAsync(DateTime shipdate, params string[] includeList)
        {
            return await GetAllAsync(o => o.ShipDate == shipdate, includeList);

        }
    }
}
