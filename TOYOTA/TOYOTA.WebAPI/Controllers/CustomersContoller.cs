using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using TOYOTA.Busines.Interfaces;
using TOYOTA.Model.Dtos.Customer;

namespace TOYOTA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        private readonly ICustomerBs _customerBs;  
        
        public CustomersController(ICustomerBs customerBs)
        {
            _customerBs = customerBs;        
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet]
        public async Task<ActionResult> GetAllCustomers()
        {
            #region Entity-Dto Mapping Method 2
            //var returnList =
            //        customers.Select(v => new CustomerGetDto()
            //        {
            //            FirstName = v.FirstName == null
            //            ? " "
            //            : v.FirstName.ToLower(),
            //            LastName = v.LastName == null
            //            ? " "
            //            : v.LastName.ToUpper(),
            //            PhoneNumber = v.PhoneNumber == null
            //            ? 0
            //            : v.PhoneNumber

            //        }).ToList();

            //return returnList;
            #endregion

            var apiResponse = await _customerBs.GetCustomersAsync();
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("bylastname")]
        public async Task<ActionResult> GetAllCustomersByLastName([FromQuery] string lastname)
        {
            var apiResponse = await _customerBs.GetCustomersByLastNameAsync(lastname);
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("byfirstname")]
        public async Task<ActionResult> GetAllCustomersByFirstName([FromQuery] string firstname)
        {
            var apiResponse = await _customerBs.GetCustomersByFirstNameAsync(firstname);
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<CustomerGetDto>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var apiResponse = await _customerBs.GetByIdAsync(id);
            return SendResponse(apiResponse);
        }

        [HttpPost]
        public async Task<ActionResult> SaveNewCustomer([FromBody] CustomerPostDto dto)
        {
            var apiResponse = await _customerBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = apiResponse.Data.CustomerId }, apiResponse.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerPutDto dto)
        {
            var apiResponse = await _customerBs.UpdateAsync(dto);
            return SendResponse(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var apiResponse = await _customerBs.DeleteAsync(id);
            return SendResponse(apiResponse);
        }
    }
}
