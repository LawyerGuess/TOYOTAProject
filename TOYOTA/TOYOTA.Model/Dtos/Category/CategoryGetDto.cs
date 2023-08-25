using Infrastructure.Model;

namespace TOYOTA.Model.Dtos.Category
{
    public class CategoryGetDto : IDto
    {
        public string VehicleName { get; set; }
        public string CategoryName { get; set; }
        public string Pack { get; set; }
        public string Description { get; set; }
        public double? VehicleEngine { get; set; }
        public decimal? UnitPrice { get; set; }       

    }
}
