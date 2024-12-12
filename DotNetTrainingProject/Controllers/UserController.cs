using DotNetTrainingProject.Entities;
using DotNetTrainingProject.Models.Requests;
using DotNetTrainingProject.Models.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingProject.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private const string DEFAULT_ROLE = "Customer";

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RequestForRegister request)
        {
            var existUser = await _userManager.FindByEmailAsync(request.Email);
            if (existUser != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = "User already exist!" });
            }

            ApplicationUser user = new ApplicationUser()
            {
                UserName = request.UserName,
                Email = request.Email,
                FullName = request.FullName,
                DateOfBirth = request.DateOfBirth,
                Address = request.Address,
                ProfilePictureUrl = request.ProfilePictureUrl,
                Description = request.Description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Create user failed!" });
            }
            await _userManager.AddToRoleAsync(user, DEFAULT_ROLE);
            return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "Create user successfully!" });
        }
    }
}
