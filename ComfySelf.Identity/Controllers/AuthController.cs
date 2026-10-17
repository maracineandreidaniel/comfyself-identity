using ComfySelf.Identity.Entities;
using ComfySelf.Identity.Models;
using ComfySelf.Identity.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ComfySelf.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        public static User user = new();


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
            var user = await authService.RegisterAsync(request);
            if (user is null)
            {
                return BadRequest("Username already exists");
            }

            return Ok(user);

        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDTO>> Login(UserDTO request)
        {
            var result = await authService.LoginAsync(request);
            if (result is null)
            {
                return BadRequest("Invalid username or password");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TokenResponseDTO>> RefreshToken(RefreshTokenRequestDTO request)
        {
            var result = await authService.RefreshTokensAsync(request);
            if (result is null || result.AccessToken is null || result.RefreshToken is null)
            {
                return Unauthorized("Invalid refresh token");
            }

            return Ok(result);
        }
    }
}
