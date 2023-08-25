using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TOYOTA.Busines.Interfaces;
using TOYOTA.Model.Dtos.Category;

namespace TOYOTA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryBs _categoryBs;

        public CategoriesController(ICategoryBs categoryBs)
        {
            _categoryBs = categoryBs;
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllCategories()
        {          
            var apiResponse = await _categoryBs.GetCategoriesAsync("Vehicle");
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("bydesc")]
        public async Task<ActionResult> GetAllCategoriesByDesc([FromQuery] string desc)
        {
            var apiResponse = await _categoryBs.GetCategoriesByDescAsync(desc, "Vehicle");
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("bypack")]
        public async Task<ActionResult> GetAllCategoriesByPack([FromQuery] string pack)
        {
            var apiResponse = await _categoryBs.GetCategoriesByPackAsync(pack, "Vehicle");
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("byyear")]
        public async Task<ActionResult> GetAllCategoriesByPrice([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var apiResponse = await _categoryBs.GetCategoriesByPriceAsync(min, max, "Vehicle");
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<CategoryGetDto>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var apiResponse = await _categoryBs.GetByIdAsync(id, "Vehicle");
            return SendResponse(apiResponse);
        }

        [HttpPost]
        public async Task<ActionResult> SaveNewCategory([FromBody] CategoryPostDto dto)
        {
            var apiResponse = await _categoryBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = apiResponse.Data.CategoryId }, apiResponse.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryPutDto dto)
        {
            var apiResponse = await _categoryBs.UpdateAsync(dto);
            return SendResponse(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var apiResponse = await _categoryBs.DeleteAsync(id);
            return SendResponse(apiResponse);
        }
    }
}
