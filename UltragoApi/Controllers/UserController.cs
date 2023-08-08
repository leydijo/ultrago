using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Ultrago.Models.Entity;
using Ultrago.Models.Response;
using Ultrago.Services;
using Ultrago.Services.Interfaces;

namespace ultragoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IUserService _userService;

        public UserController(IJwtTokenService jwtTokenService, IUserService userService)
        {
            _jwtTokenService = jwtTokenService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User userRequest)
        {
            var user = await _userService.Register(userRequest.UserName, userRequest.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Username is already" });
            }


            return Ok(new RegisterUserResponse
            {
                Id = user.Id,
                Username = user.UserName
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User userRequest)
        {
            var user = await _userService.Authenticate(userRequest.UserName, userRequest.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var token = _jwtTokenService.CreateToken(user);
            return Ok(new { Token = token });
        }


    }
}
