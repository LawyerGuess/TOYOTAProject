using Infrastructure.Model;

namespace TOYOTA.Model.Dtos.SparePart
{
    public class SparePartGetDto : IDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
