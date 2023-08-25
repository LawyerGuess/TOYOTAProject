using Infrastructure.Model;

namespace TOYOTA.Model.Dtos.Order
{
    public class OrderPostDto : IDto
    {
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string ShipAdress { get; set; }
    }
}
