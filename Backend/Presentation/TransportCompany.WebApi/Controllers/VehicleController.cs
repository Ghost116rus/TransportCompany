using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Aplication.Interfaces;
using TransportCompany.Aplication.Requests.Orders;

namespace TransportCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost("GetVehicleForOrder")]
        public async Task<IActionResult> GetVehicleForOrder([FromBody] VehicleForOrder request)
        {
            var vehicleList = await _vehicleService.GetVehicleForOrder(request);
            return Ok(vehicleList);
        }


        [HttpGet("GetVehicleByNumber")]
        public async Task<IActionResult> GetVehicleByNumber(string number)
        {
            var vehicle = await _vehicleService.GetVehicleByIdNumber(number);
            return Ok(vehicle);
        }

        [HttpGet("GetAllVehicles")]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await _vehicleService.GetAllVehicle();
            return Ok(vehicles);
        }
    }
}
