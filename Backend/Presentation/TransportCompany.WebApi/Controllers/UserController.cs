using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Aplication.Interfaces;
using TransportCompany.Aplication.Requests;

namespace TransportCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Authorizate")]
        public async Task<IActionResult> Authorizate([FromBody]RequestLogin requestlogin)
        {
            var result = await _userService.Login(requestlogin);
            return Ok(result);
        }
    }
}
