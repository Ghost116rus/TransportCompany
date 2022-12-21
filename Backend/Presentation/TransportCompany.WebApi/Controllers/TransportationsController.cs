using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Aplication.Interfaces;

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
    }
}
