using Infrastructure.Model;

namespace TOYOTA.Model.Dtos.Supplier
{
    public class SupplierGetDto : IDto
    {
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public int Phone { get; set; }
    }
}
