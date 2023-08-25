using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using TOYOTA.Busines.Interfaces;
using TOYOTA.Model.Dtos.Supplier;

namespace TOYOTA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : BaseController
    {
        private readonly ISupplierBs _supplierBs;        

        public SuppliersController(ISupplierBs supplierBs)
        {
            _supplierBs = supplierBs;          
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<SupplierGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet]
        public async Task<ActionResult> GetAllSuppliers()
        {
            var apiResponse = await _supplierBs.GetSuppliersAsync();
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<SupplierGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("byadress")]
        public async Task<ActionResult> GetAllSuppliersByAdress([FromQuery] string adress)
        {
            var apiResponse = await _supplierBs.GetSuppliersByAdressAsync(adress);
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<SupplierGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("bycityandcountry")]
        public async Task<ActionResult> GetAllSuppliersByCityAndCountry([FromQuery] string city, [FromQuery] string country)
        {
            var apiResponse = await _supplierBs.GetSuppliersByCityAndCountryAsync(city, country);
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<SupplierGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("bycontactperson")]
        public async Task<ActionResult> GetAllSuppliersByContactPerson([FromQuery] string contactperson)
        {
            var apiResponse = await _supplierBs.GetSuppliersByContactPersonAsync(contactperson);
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<SupplierGetDto>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var apiResponse = await _supplierBs.GetByIdAsync(id);
            return SendResponse(apiResponse);
        }

        [HttpPost]
        public async Task<ActionResult> SaveNewVehicle([FromBody] SupplierPostDto dto)
        {
            var apiResponse = await _supplierBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = apiResponse.Data.SupplierId }, apiResponse.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSupplier([FromBody] SupplierPutDto dto)
        {
            var apiResponse = await _supplierBs.UpdateAsync(dto);
            return SendResponse(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var apiResponse = await _supplierBs.DeleteAsync(id);
            return SendResponse(apiResponse);
        }
    }
}
