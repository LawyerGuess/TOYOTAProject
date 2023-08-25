using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using TOYOTA.Busines.Interfaces;
using TOYOTA.Model.Dtos.Order;

namespace TOYOTA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly IOrderBs _orderBs;       

        public OrdersController(IOrderBs orderBs)
        {
            _orderBs = orderBs;           
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet]
        public async Task<ActionResult> GetAllOrders()
        {
            #region Entity-Dto Mapping Method 2
            //var orders = _orderBs.GetOrders();
            //var returnList =
            //    orders.Select(o => new OrderGetDto()
            //    {
            //        OrderDate = o.OrderDate == null
            //                ? DateTime.MinValue
            //                : o.OrderDate,
            //        ShipDate = o.ShipDate == null
            //                ? DateTime.MinValue
            //                : o.ShipDate,
            //        ShipAdress = o.ShipAdress == null
            //                ? " "
            //                : o.ShipAdress

            //    }).ToList();

            //return returnList; 
            #endregion

            var apiResponse = await _orderBs.GetOrdersAsync();
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("byshipadress")]
        public async Task<ActionResult> GetAllOrdersByShipAdress([FromQuery] string shipadress)
        {
            var apiResponse = await _orderBs.GetOrdersByShipAdressAsync(shipadress);
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("byshipdate")]
        public async Task<ActionResult> GetAllOrdersByShipDate([FromQuery] DateTime shipdate)
        {
            var apiResponse = await _orderBs.GetOrdersByShipDateAsync(shipdate);
            return SendResponse(apiResponse);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<OrderGetDto>))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var apiResponse = await _orderBs.GetByIdAsync(id);
            return SendResponse(apiResponse);
        }

        [HttpPost]
        public async Task<ActionResult> SaveNewOrder([FromBody] OrderPostDto dto)
        {
            var apiResponse = await _orderBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = apiResponse.Data.OrderId }, apiResponse.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderPutDto dto)
        {
            var apiResponse = await _orderBs.UpdateAsync(dto);
            return SendResponse(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var apiResponse = await _orderBs.DeleteAsync(id);
            return SendResponse(apiResponse);
        }
    }
}
