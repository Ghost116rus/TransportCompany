using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Aplication.Interfaces;
using TransportCompany.Aplication.Requests.CreateTransportation;

namespace TransportCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportationsController : ControllerBase
    {
        private readonly ITransportationService _transportationService;

        public TransportationsController(ITransportationService transportationService)
        {
            _transportationService = transportationService;
        }

        [HttpGet("GetActiveTransportations")]
        public async Task<IActionResult> GetActiveTransportations()
        {
            var transportations = await _transportationService.GetActiveTransportations();
            return Ok(transportations);
        }

        [HttpGet("GetAllTransportations")]
        public async Task<IActionResult> GetAllTransportations()
        {
            var transportations = await _transportationService.GetAllTransportations();
            return Ok(transportations);
        }

        [HttpPost("CreateTransportation")]
        public async Task<IActionResult> CreateTransportation([FromBody] RequestToCreateTransportation request)
        {
            var response = await _transportationService.CreateTransportation(request);
            return Ok(response);
            //return Ok();
        }

        /*
         {
          "requestNumber": 8,
          "numSendingStorage": 3,
          "total_length": 18000,
          "car_load": 10,
          "total_shipping_cost": 150000,
          "vehicleID": "В238НА116        ",
          "driverID": "9222536972"
        }
         */
    }
}
