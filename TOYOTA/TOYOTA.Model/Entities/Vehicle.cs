using Infrastructure.Model;

namespace TOYOTA.Model.Entities
{
    public class Vehicle:IEntity
    {
        public int? VehicleId { get; set; }
        public string VehicleName { get; set; }        
        public int? Year { get; set; }
        public string Color { get; set; }        
        public short? UnitsInStock { get; set; } 
        public int? SupplierId { get; set; }   
        public int? CategoryId { get; set; }
        public bool? IsActive { get; set; }


        public List<Category>? Category { get; set; }

    }
}
