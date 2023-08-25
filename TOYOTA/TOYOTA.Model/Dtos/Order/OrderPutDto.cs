using Infrastructure.Model;

namespace TOYOTA.Model.Dtos.Order
{
    public class OrderPutDto:IDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string ShipAdress { get; set; }
    }
}
