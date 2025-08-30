using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conecta.Doa.Application.Presentation.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{

    [Authorize]
    [HttpGet("me")]
    public IActionResult GetMe()
    {
        return Ok(User.Claims.ToDictionary(c => c.Type, c => c.Value));
    }
}
