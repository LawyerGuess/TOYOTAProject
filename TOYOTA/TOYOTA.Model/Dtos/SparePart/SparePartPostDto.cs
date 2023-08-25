using Infrastructure.Model;

namespace TOYOTA.Model.Dtos.SparePart
{
    public class SparePartPostDto : IDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
