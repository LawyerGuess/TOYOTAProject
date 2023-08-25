using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using TOYOTA.Busines.Interfaces;
using TOYOTA.Model.Dtos.SparePart;

namespace TOYOTA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SparePartsController : BaseController
    {
        private readonly ISparePartBs _sparePartBs;
        
        public SparePartsController(ISparePartBs sparePartBs)
        {
            _sparePartBs = sparePartBs;            
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<SparePartGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet]
        public async Task<ActionResult> GetAllSpareParts()
        {
            var apiResponse = await _sparePartBs.GetSparePartsAsync();
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<SparePartGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("byname")]
        public async Task<ActionResult> GetAllSparePartsByName([FromQuery] string name)
        {
            var apiResponse = await _sparePartBs.GetSparePartsByNameAsync(name);
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<SparePartGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("bystock")]
        public async Task<ActionResult> GetAllSparePartsByStock([FromQuery] short min, [FromQuery] short max)
        {
            var apiResponse = await _sparePartBs.GetSparePartsByStockAsync(min, max);
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<SparePartGetDto>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var apiResponse = await _sparePartBs.GetByIdAsync(id);
            return SendResponse(apiResponse);
        }

        [HttpPost]
        public async Task<ActionResult> SaveNewSparePart([FromBody] SparePartPostDto dto)
        {
            var apiResponse = await _sparePartBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = apiResponse.Data.SparePartId }, apiResponse.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSparePart([FromBody] SparePartPutDto dto)
        {
            var apiResponse = await _sparePartBs.UpdateAsync(dto);
            return SendResponse(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSparePart(int id)
        {
            var apiResponse = await _sparePartBs.DeleteAsync(id);
            return SendResponse(apiResponse);
        }
    }
}
