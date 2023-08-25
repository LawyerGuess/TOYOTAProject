using Infrastructure.DataAccess;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Interfaces
{
    public interface ISparePartRepository : IBaseRepository<SparePart>
    {
        Task<List<SparePart>> GetByNameAsync(string name, params string[] includeList);
        Task<List<SparePart>> GetByStockAsync(short min, short max, params string[] includeList);

        Task<SparePart> GetByIdAsync(int sparepartId, params string[] includeList);
    }
}
