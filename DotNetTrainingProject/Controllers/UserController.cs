using DotNetTrainingProject.Models.Requests;
using DotNetTrainingProject.Models.Responses;
using DotNetTrainingProject.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingProject.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RequestForRegister request)
        {
            var result = await _userService.Register(request);
            if (!result)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new Response { Status = "Error", Message = "Create user failed!" });
            }
            return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "Create user successfully!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] RequestForLogin request)
        {
            var result = await _userService.Login(request);
            if (String.IsNullOrEmpty(result))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new Response { Status = "Error", Message = "Login failed!" });
            }
            return Ok("Access token:" + result);
        }
    }
}
