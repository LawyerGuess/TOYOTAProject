using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using TOYOTA.Busines.Interfaces;
using TOYOTA.Model.Dtos.Vehicle;

namespace TOYOTA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : BaseController
    {
        //Entity-Dto Mapping Method 1
        private readonly IVehicleBs _vehicleBs;
        public VehiclesController(IVehicleBs vehicleBs)
        {
            _vehicleBs = vehicleBs;           
        }        

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<VehicleGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet]
        public async Task<ActionResult> GetAllVehicles()
        {
            #region Entity-Dto mapping Method 1
            //var returnList = new List<VehicleGetDto>();

            //foreach (var vehicle in vehicles)
            //{
            //    var dto = new VehicleGetDto();
            //    dto.VehicleName = vehicle.VehicleName==null 
            //                      ? " " 
            //                      : vehicle.VehicleName.ToUpper();
            //    dto.Year = vehicle.Year;
            //    dto.Color = vehicle.Color.ToLower();

            //    returnList.Add(dto);

            //}
            //return returnList; 
            #endregion            

            var apiResponse = await _vehicleBs.GetVehiclesAsync("Category");
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<VehicleGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("bystock")]
        public async Task<ActionResult> GetAllVehiclesByStock([FromQuery] short min, [FromQuery] short max)
        {
            var apiResponse = await _vehicleBs.GetVehiclesByStockAsync(min, max, "Category");
            return SendResponse(apiResponse);         
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<VehicleGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("byyear")]
        public async Task<ActionResult> GetAllVehiclesByYear([FromQuery] int min, [FromQuery] int max)
        {
            var apiResponse = await _vehicleBs.GetVehiclesByYearAsync(min, max, "Category");
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<VehicleGetDto>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var apiResponse = await _vehicleBs.GetByIdAsync(id, "Category");
            return SendResponse(apiResponse);
        }

        [HttpPost]
        public async Task<ActionResult> SaveNewVehicle([FromBody] VehiclePostDto dto)
        {
            var apiResponse = await _vehicleBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = apiResponse.Data.VehicleId }, apiResponse.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehicle([FromBody] VehiclePutDto dto)
        {
            var apiResponse = await _vehicleBs.UpdateAsync(dto);
            return SendResponse(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var apiResponse = await _vehicleBs.DeleteAsync(id);
            return SendResponse(apiResponse);
        }
    }
}
