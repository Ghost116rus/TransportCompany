using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Aplication.Interfaces;

namespace TransportCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoragesController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public StoragesController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStorages()
        {
            var storages = await _storageService.GetAllStorages();
            return Ok(storages);
        }

        [HttpGet("{requestId}")]
        public async Task<IActionResult> GetStoragesRequest(int requestId)
        {
            var storages = await _storageService.GetStoragesRequest(requestId);
            return Ok(storages.StoragesTransportations);
        }
    }
}
