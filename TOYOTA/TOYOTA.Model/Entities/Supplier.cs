using Infrastructure.Model;

namespace TOYOTA.Model.Entities
{
    public class Supplier:IEntity
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Phone { get; set; }
        public int Fax { get; set; }
        public bool? IsActive { get; set; }


    }
}
