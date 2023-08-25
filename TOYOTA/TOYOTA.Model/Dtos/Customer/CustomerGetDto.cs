using Infrastructure.Model;

namespace TOYOTA.Model.Dtos.Customer
{
    public class CustomerGetDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        
    }
}
