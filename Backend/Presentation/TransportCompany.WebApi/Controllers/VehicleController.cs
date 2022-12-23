using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Aplication.Interfaces;

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
