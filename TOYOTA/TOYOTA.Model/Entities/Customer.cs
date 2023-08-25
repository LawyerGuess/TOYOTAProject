using Infrastructure.Model;

namespace TOYOTA.Model.Entities
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsActive { get; set; }

    }
}
