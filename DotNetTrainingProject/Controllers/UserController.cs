using DotNetTrainingProject.MailUtilities;
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
        private ISendMailService _sendMailService;

        public UserController(IUserService userService, ISendMailService sendMailService)
        {
            _userService = userService;
            _sendMailService = sendMailService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RequestForRegister request)
        {
            var result = await _userService.Register(request);
            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Create user failed!" });
            }
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Create user successfully!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] RequestForLogin request)
        {
            var result = await _userService.Login(request);
            if (String.IsNullOrEmpty(result))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Login failed!" });
            }
            return Ok("Access token: \n" + result);
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword([FromBody] string userName)
        {
            var result = await _sendMailService.SendMail(userName);
            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Send email failed!" });
            }
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Send email successfully!" });
        }
    }
}
