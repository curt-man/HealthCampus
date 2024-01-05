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

        private readonly IAppUserManagerService _appUserManager;

        public AuthenticationController(IAppUserManagerService appUserManagement)
        {
            _response = new ResponseDto();
            _appUserManager = appUserManagement;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<ResponseDto>> Register([FromBody] AppUserRegisterRequestDto request)
        {
            try
            {
                AppUser registeredUser = await _appUserManager.RegisterAsync(request);

                await _appUserManager.AssignRoleAsync(registeredUser, RolesEnum.User);

                string token = await _appUserManager.LogInAsync(registeredUser, request.Password);

                _response.Result = token;
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return Ok(_response);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ResponseDto> Login([FromBody] AppUserLoginRequestDto request)
        {
            try
            {
                var token = await _appUserManager.LogInAsync(request);
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
