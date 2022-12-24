using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Aplication.Interfaces;
using TransportCompany.Aplication.Requests.Orders;
using TransportCompany.Aplication.Services;

namespace TransportCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet("GetDetailInfo")]
        public async Task<IActionResult> GetDetailDriverInfo(string Driver_license_number)
        {
            var driver = await _driverService.GetDetailDriverInfo(Driver_license_number);
            return Ok(driver);
        }

        [HttpGet("GetAllDrivers")]
        public async Task<IActionResult> GetDrivers()
        {
            var driversBO = await _driverService.GetDrivers();
            return Ok(driversBO);
        }


        [HttpPost("GetDriversForOrder")]
        public async Task<IActionResult> GetVehicleForOrder([FromBody] DriverForOrder request)
        {
            var vehicleList = await _driverService.GetDriversForOrder(request);
            return Ok(vehicleList);
        }
    }
}
