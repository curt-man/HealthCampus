using HealthCampus.CommonUtilities.Dto;
using HealthCampus.CommonUtilities.Utilities;
using HealthCampus.Services.AuthenticationServiceAPI.Data;
using HealthCampus.Services.AuthenticationServiceAPI.Models;
using HealthCampus.Services.AuthenticationServiceAPI.Models.Dto;
using HealthCampus.Services.AuthenticationServiceAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthCampus.Services.AuthenticationServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ResponseDto _response;

        private void SetErrorMessageToResponse(string message)
        {
            _response.IsSuccess = false;
            _response.Message = message;
        }

        private readonly JwtService _jwtService;
        private readonly AuthenticationDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthenticationController(UserManager<AppUser> userManager, AuthenticationDbContext authenticationDbContext, RoleManager<IdentityRole<Guid>> roleManager, JwtService jwtService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _dbContext = authenticationDbContext;
            _roleManager = roleManager;
            _jwtService = jwtService;
            _signInManager = signInManager;
            _response = new ResponseDto();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<ResponseDto>> RegisterAsync([FromBody] AppUserRegistrationRequestDto request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.EmailAddress);
                if (user != null)
                {
                    throw new Exception("User already exists!");
                }
                user = new AppUser()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.EmailAddress,
                    UserName = request.EmailAddress,
                    RegistrationDate = DateTime.UtcNow
                };


                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    string errors = string.Empty;
                    foreach (var error in result.Errors)
                    {
                        errors += error.Description + Environment.NewLine;
                    }
                    throw new ArgumentException(errors);
                }

                result = await _userManager.AddToRoleAsync(user, RolesAndPasswords.User.Role);
                if (!result.Succeeded)
                {
                    string errors = string.Empty;
                    foreach (var error in result.Errors)
                    {
                        errors += error.Description + Environment.NewLine;
                    }
                    throw new ArgumentException(errors);
                }
                _response.Result = user;

                var jwtToken = _jwtService.GenerateJwtToken(user);
                _response.Message = jwtToken;

            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return Ok(_response);
        }



        [HttpPost("Login")]
        public async Task<ResponseDto> LoginAsync([FromBody] AppUserLoginRequestDto request)
        {
            try
            {
                AppUser user;
                if (request.EmailOrUsername.Contains("@"))
                {
                    user = await _userManager.FindByEmailAsync(request.EmailOrUsername);
                }
                else
                {
                    user = await _userManager.FindByNameAsync(request.EmailOrUsername);
                }
                if (user == null)
                {
                    throw new Exception("Invalid credentials");
                }

                var isPasswordIsValid = await _userManager.CheckPasswordAsync(user, request.Password);

                if (!isPasswordIsValid)
                {
                    throw new Exception("Invalid credentials");
                }

                //for development
                _response.Result = user;

                var jwtToken = _jwtService.GenerateJwtToken(user);
                _response.Message = jwtToken;
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return _response;
        }

    }
}
