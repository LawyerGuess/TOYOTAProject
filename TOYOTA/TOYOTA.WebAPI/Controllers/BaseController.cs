using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace TOYOTA.WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        public ActionResult SendResponse<T>(ApiResponse<T> apiResponse)
        {
            if (apiResponse.StatusCode == StatusCodes.Status204NoContent)
                return new ObjectResult(null) { StatusCode = apiResponse.StatusCode };

            return new ObjectResult(apiResponse) { StatusCode = apiResponse.StatusCode };
        }
    }
}
