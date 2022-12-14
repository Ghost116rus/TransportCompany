using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Aplication.BO;
using TransportCompany.Aplication.Interfaces;
using TransportCompany.Aplication.Requests;
using TransportCompany.Aplication.Requests.CreateTransportation;
using TransportCompany.Aplication.Services;

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

        [HttpGet("GetDetailInfoByLicenseNumber")]
        public async Task<IActionResult> GetDetailInfoAboutTransportation(string license)
        {
            var transportation = await _transportationService.GetDetailInfoByLicenseNumber(license);
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


        [HttpGet("SendProducts")]
        public async Task<IActionResult> SendProducts(int transportationNumber)
        {
            var result = await _transportationService.SendProducts(transportationNumber);
            return Ok(result);
        }

        [HttpGet("CancelTransportation")]
        public async Task<IActionResult> CancelTransportation(int transportationNumber)
        {
            var result = await _transportationService.CancelTransportation(transportationNumber);
            return Ok(result);
        }

        [HttpGet("CompleteTransportation")]
        public async Task<IActionResult> CompleteTransportation(int transportationNumber)
        {
            var result = await _transportationService.CompleteTransportation(transportationNumber);
            return Ok(result);
        }


        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] RequestChangeStatusTransportation request)
        {
            var result = await _transportationService.ChangeStatus(request);
            return Ok(result);
        }
    }
}
