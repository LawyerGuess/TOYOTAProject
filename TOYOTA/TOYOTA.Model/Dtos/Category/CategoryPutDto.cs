using Infrastructure.Model;

namespace TOYOTA.Model.Dtos.Category
{
    public class CategoryPutDto:IDto
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Pack { get; set; }
        public string Description { get; set; }
        public byte? Picture { get; set; }
        public int? VehicleId { get; set; }
        public decimal? UnitPrice { get; set; }
        public double? VehicleEngine { get; set; }
    }
}
