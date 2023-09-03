using HealthCampus.CommonUtilities.Dto;
using HealthCampus.CommonUtilities.Enums;
using HealthCampus.Services.AppUserAPI.Data;
using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Models.Dto;
using HealthCampus.Services.AppUserAPI.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AppUserAPI.Controllers
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

        private readonly AppUserDbContext _dbContext;
        private readonly IAppUserManagerService _appUserManager;

        public AppUserController(AppUserDbContext AppUserDbContext, IAppUserManagerService appUserManager)
        {
            _dbContext = AppUserDbContext;
            _response = new ResponseDto();
            _appUserManager = appUserManager;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<ResponseDto>> GetAllUsersAsync()
        {
            try
            {
                var users = await _dbContext.Users.ToListAsync();
                _response.Result = users;
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return Ok(_response);
        }

        [HttpPost]
        [Route("AddNewUser")]
        public async Task<ActionResult<ResponseDto>> RegisterAsync([FromBody] AdminAppUserRegistrationRequestDto request)
        {
            try
            { 
                AppUser registeredUser =
                    await _appUserManager.RegisterAppUser<AdminAppUserRegistrationRequestDto>(request);

                await _appUserManager.AssignRoleToAppUser(registeredUser, request.AppRole);

                string token = await _appUserManager.LogInAppUser(registeredUser, request.Password);

                _response.Result = token;
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return Ok(_response);
        }


    }
}
