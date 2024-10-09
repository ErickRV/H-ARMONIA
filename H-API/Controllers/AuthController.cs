using HARMONIA.Domain.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace H_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [HttpPost("LogIn")]
        public IActionResult LogIn(LogInInput dto) { 
            return Ok();
        }

        [HttpPost("Refresh")]
        public IActionResult RefreshToken(string refreshToken)
        {
            return Ok();
        }
    }
}
