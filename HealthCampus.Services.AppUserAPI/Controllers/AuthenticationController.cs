using HealthCampus.CommonUtilities.Dto;
using HealthCampus.CommonUtilities.Enums;
using HealthCampus.Services.AppUserAPI.Data;
using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Models.Dtos;
using HealthCampus.Services.AppUserAPI.Services;
using HealthCampus.Services.AppUserAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HealthCampus.Services.AppUserAPI.Controllers
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

        private readonly AppUserDbContext _dbContext;
        private readonly IAppUserManagerService _appUserManager;

        public AuthenticationController(AppUserDbContext AppUserDbContext, IAppUserManagerService appUserManagement)
        {
            _dbContext = AppUserDbContext;
            _response = new ResponseDto();
            _appUserManager = appUserManagement;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<ResponseDto>> RegisterAsync([FromBody] AppUserRegisterRequestDto request)
        {
            try
            {
                AppUser registeredUser = await _appUserManager.Register(request);

                await _appUserManager.AssignRoleTo(registeredUser, RolesEnum.User);

                string token = await _appUserManager.LogIn(registeredUser, request.Password);

                _response.Result = token;
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
                var token = await _appUserManager.LogIn(request);
                _response.Result = token;
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return _response;
        }


    }
}
