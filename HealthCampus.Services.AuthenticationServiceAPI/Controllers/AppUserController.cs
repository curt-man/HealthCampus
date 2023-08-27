using Azure.Storage.Blobs.Models;
using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AuthenticationServiceAPI.Data;
using HealthCampus.Services.AuthenticationServiceAPI.Models;
using HealthCampus.Services.AuthenticationServiceAPI.Models.Dto;
using HealthCampus.Services.AuthenticationServiceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AuthenticationServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly ResponseDto _response;

        private void SetErrorMessageToResponse(string message)
        {
            _response.IsSuccess = false;
            _response.Message = message;
        }

        private readonly AuthenticationDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public AppUserController(UserManager<AppUser> userManager, AuthenticationDbContext authenticationDbContext, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _dbContext = authenticationDbContext;
            _roleManager = roleManager;
            _response = new ResponseDto();
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<ResponseDto>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();
                _response.Result = users;
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return Ok(_response);
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult<ResponseDto>> RegisterAsync([FromBody] AdminRegistrationRequestDto request)
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

                result = await _userManager.AddToRoleAsync(user, request.AppRole);
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


            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return Ok(_response);
        }

    }
}
