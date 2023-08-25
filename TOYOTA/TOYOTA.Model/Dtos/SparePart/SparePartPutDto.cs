using Infrastructure.Model;

namespace TOYOTA.Model.Dtos.SparePart
{
    public class SparePartPutDto:IDto
    {
        public int SparePartId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public short Stock { get; set; }
    }
}
