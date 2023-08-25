using Infrastructure.Model;

namespace TOYOTA.Model.Dtos.Employee
{
    public class EmployeePostDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Salary { get; set; }
        public byte[]? Photo { get; set; }
        public string PhotoPath { get; set; }
        //public string Base64Photo { get; set; }
       
        
    }
}
