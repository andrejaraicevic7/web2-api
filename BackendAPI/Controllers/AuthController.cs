using BackendAPI.DTO;
using BackendAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            string authToken = _authService.Login(loginDto);
            if (authToken != null)
            {
                if (authToken == string.Empty)
                {
                    return BadRequest("Wrong password!");

                }

                return Ok(authToken);
            }
            else
            {
                return BadRequest("Wrong email!");
            }
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto regModel)
        {
            try
            {
                _authService.Register(regModel);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("socialLogin")]
        public IActionResult SocialLogin([FromBody] UserDto socialLoginModel)
        {
            var token = _authService.SocialLogin(socialLoginModel);

            if (token != null)
            {
                if (token == string.Empty)
                {
                    return BadRequest("Wrong password!");

                }
                return Ok(token);
            }
            else
            {
                return BadRequest("Wrong email!");
            }
        }

    }
}

