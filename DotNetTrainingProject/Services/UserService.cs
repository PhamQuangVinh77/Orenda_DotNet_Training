using DotNetTrainingProject.Entities;
using DotNetTrainingProject.Models.Requests;
using DotNetTrainingProject.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotNetTrainingProject.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;
        private readonly ILogger<UserService> _logger;
        private const string DEFAULT_ROLE = "Customer";
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager, IConfiguration config, ILogger<UserService> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _config = config;
            _logger = logger;
        }

        public async Task<bool> Register(RequestForRegister request)
        {
            try
            {
                var existUser = await _userManager.FindByEmailAsync(request.Email);
                if (existUser != null)
                {
                    return false;
                } // Check exist email in database

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
                    return false;
                }
                await _userManager.AddToRoleAsync(user, DEFAULT_ROLE); // Add new user with role is Customer
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<string> Login(RequestForLogin request)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
                if (!result.Succeeded) return String.Empty;
                var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
                var token = new JwtSecurityToken(
                        issuer: _config["JWT:ValidIssuer"],
                        audience: _config["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(1),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256Signature)
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return String.Empty;
            }
        }
    }
}
