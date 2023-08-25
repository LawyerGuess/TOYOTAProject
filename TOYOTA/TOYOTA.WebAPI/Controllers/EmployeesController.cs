using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using TOYOTA.Busines.Interfaces;
using TOYOTA.Model.Dtos.Employee;

namespace TOYOTA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeBs _employeeBs;        

        public EmployeesController(IEmployeeBs employeeBs)
        {
            _employeeBs = employeeBs;            
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<EmployeeGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            #region Entity-Dto Mapping Method 2
            //var employees = _employeeBs.GetEmployees();
            //var returnList =
            //    employees.Select(e => new EmployeeGetDto()
            //    {
            //        FirstName = e.FirstName == null
            //                ? " "
            //                : e.FirstName.ToLower(),
            //        LastName = e.LastName == null
            //                ? " "
            //                : e.LastName.ToUpper(),
            //        Salary = e.Salary == null
            //                ? 0
            //                : e.Salary

            //    }).ToList();

            //return returnList; 
            #endregion

            var apiResponse = await _employeeBs.GetEmployeesAsync();
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<EmployeeGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("byannualleave")]
        public async Task<ActionResult> GetAllEmployeesByAnnualLeave(short annualleave)
        {
            var apiResponse = await _employeeBs.GetEmployeesByAnnualLeaveAsync(annualleave);
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<EmployeeGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("bybirthdate")]
        public async Task<ActionResult> GetAllEmployeesByBirthDate([FromQuery] DateTime birthdate)
        {
            var apiResponse = await _employeeBs.GetEmployeesByBirthDateAsync(birthdate);
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<EmployeeGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("bysalary")]
        public async Task<ActionResult> GetAllEmployeesBySalary([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var apiResponse = await _employeeBs.GetEmployeesBySalaryAsync(min, max);
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<EmployeeGetDto>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var apiResponse = await _employeeBs.GetByIdAsync(id);
            return SendResponse(apiResponse);
        }

        [HttpPost]
        public async Task<ActionResult> SaveNewEmployee([FromBody] EmployeePostDto dto)
        {
            var apiResponse = await _employeeBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = apiResponse.Data.EmployeeId }, apiResponse.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeePutDto dto)
        {
            var apiResponse = await _employeeBs.UpdateAsync(dto);
            return SendResponse(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var apiResponse = await _employeeBs.DeleteAsync(id);
            return SendResponse(apiResponse);
        }
    }
}
