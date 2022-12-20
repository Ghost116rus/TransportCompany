using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Aplication.Interfaces;

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

        [HttpGet("PandingOrders")]
        public async Task<IActionResult> GetPandingsOrders()
        {
            var orders = await _orderService.GetAllPandingOrder();
            return Ok(orders);
        }
    }
}
