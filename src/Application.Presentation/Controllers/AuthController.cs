using Conecta.Doa.Application.Presentation.Dto;
using Conecta.Doa.Application.Presentation.Extensions;
using Conecta.Doa.Application.Presentation.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Conecta.Doa.Application.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(request);

            // var result = await _authService.CreateRegisterAsync(request);
            // if (!result.Success)
            //     return BadRequest(request);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(request);

            // if (!await _authService.LoginAsync(request))
            //     return BadRequest(request);

            return Ok();
        }
    }
}
