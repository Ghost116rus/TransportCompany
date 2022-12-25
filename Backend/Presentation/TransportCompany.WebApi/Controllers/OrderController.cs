using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Aplication.Interfaces;
using TransportCompany.Aplication.Requests.Orders;

namespace TransportCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("DetailInfo")]
        public async Task<IActionResult> GetDetailInfoAboutOrder(int number)
        {
            var order = await _orderService.GetOrderByNumber(number);
            return Ok(order);
        }

        [HttpGet("AllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("GetAllOrdersByStorageNumber")]
        public async Task<IActionResult> GetAllOrdersByStorageNumber(int number)
        {
            var orders = await _orderService.GetAllOrdersByStorageNumber(number);
            return Ok(orders);
        }

        [HttpGet("PandingOrders")]
        public async Task<IActionResult> GetPandingsOrders()
        {
            var orders = await _orderService.GetAllPandingOrder();
            return Ok(orders);
        }


        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] NewOrder newOrder)
        {
            var response = await _orderService.CreateOrder(newOrder);
            return Ok(response);    
        }


        [HttpGet("CancelOrder")]
        public async Task<IActionResult> CancelOrder(int number)
        {
            var result = await _orderService.CancelOrder(number);
            return Ok(result);
        }
    }
}
