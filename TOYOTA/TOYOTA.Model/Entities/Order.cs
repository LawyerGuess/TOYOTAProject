using Infrastructure.Model;

namespace TOYOTA.Model.Entities
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string ShipAdress { get; set; }
        public bool? IsActive { get; set; }


        public Employee? Employee { get; set; }
    }
}
