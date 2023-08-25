using Infrastructure.Model;

namespace TOYOTA.Model.Dtos.Vehicle
{
    public class VehiclePutDto:IDto
    {
        public int? VehicleId { get; set; }
        public string VehicleName { get; set; }
        public int? Year { get; set; }
        public string Color { get; set; }
        public short? UnitsInStock { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
    }
}
