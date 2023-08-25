using Infrastructure.Model;

namespace TOYOTA.Model.Dtos.Employee
{
    public class EmployeePutDto:IDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        //public byte? Photo { get; set; }
        public string Photo { get; set; }

        public short? AnnualLeave { get; set; }
        public int? Salary { get; set; }
    }
}
