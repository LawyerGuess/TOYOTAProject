using Infrastructure.Utilities.ApiResponses;
using Infrastructure.Utilities.Security.JWT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TOYOTA.Busines.Interfaces;
using TOYOTA.Model.Dtos.AdminPanelUser;

namespace TOYOTA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPanelUsersController : BaseController
    {
        private readonly IAdminPanelUserBs _adminPanelUserBs;
        private readonly IConfiguration _configuration;

        public AdminPanelUsersController(IAdminPanelUserBs adminPanelUserBs, IConfiguration configuration)
        {
            _adminPanelUserBs = adminPanelUserBs;
            _configuration = configuration;
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<AccessToken>))]
        [HttpGet("gettoken")]
        public async Task<ActionResult> GetToken()
        {            var accessToken = new JwtGenerator(_configuration).GenerateAccessToken();
            var response = new ApiResponse<AccessToken>();
            response.Data = accessToken;
            response.StatusCode = 200;

            return SendResponse(response);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<AdminPanelUserGetDto>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("login")]
        public async Task<ActionResult> LogIn([FromQuery] string userName, [FromQuery] string password)
        {
            var apiResponse = await _adminPanelUserBs.LogInAsync(userName, password);
            return SendResponse(apiResponse);
        }
    }
}
