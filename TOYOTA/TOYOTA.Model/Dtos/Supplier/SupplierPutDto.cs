using Infrastructure.Model;

namespace TOYOTA.Model.Dtos.Supplier
{
    public class SupplierPutDto:IDto
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Phone { get; set; }
        public int Fax { get; set; }
    }
}
