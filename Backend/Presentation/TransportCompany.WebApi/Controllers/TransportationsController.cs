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

        [HttpGet("GetDetailInfoAboutTransportation")]
        public async Task<IActionResult> GetDetailInfoAboutTransportation(int number)
        {
            var transportation = await _transportationService.GetDetailInfoAboutTransportation(number);
            return Ok(transportation);
        }
        
        [HttpGet("GetDetailTransportationInfoForOperator")]
        public async Task<IActionResult> GetDetailTransportationInfoForOperator(int number)
        {
            var transportation = await _transportationService.GetDetailTransportationInfoForOperator(number);
            return Ok(transportation);
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

        [HttpGet("GetGetTransportation")]
        public async Task<IActionResult> GetGetTransportation(int storageNumber)
        {
            var transportation = await _transportationService.GetGetTransportation(storageNumber);
            return Ok(transportation);
        }

        [HttpGet("GetSendTransportation")]
        public async Task<IActionResult> GetSendTransportation(int storageNumber)
        {
            var transportation = await _transportationService.GetSendTransportation(storageNumber);
            return Ok(transportation);
        }

    }
}
