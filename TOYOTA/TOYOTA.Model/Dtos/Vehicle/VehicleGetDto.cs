using Infrastructure.Model;

namespace TOYOTA.Model.Dtos.Vehicle
{
    public class VehicleGetDto:IDto
    {
        public string VehicleName { get; set; }       
        public int? Year { get; set; }
        public string Color { get; set; }           

    }
}
