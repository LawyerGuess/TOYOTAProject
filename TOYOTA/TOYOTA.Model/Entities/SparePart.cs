using Infrastructure.Model;

namespace TOYOTA.Model.Entities
{
    public class SparePart : IEntity
    {
        public int SparePartId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public short Stock { get; set; }  
        public bool? IsActive { get; set; }


    }
}
