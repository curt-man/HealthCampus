using Azure;
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

        private readonly IAppUserManagerService _appUserManager;

        public AuthenticationController(IAppUserManagerService appUserManagement)
        {
            _appUserManager = appUserManagement;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<string>> Register([FromBody] AppUserRegisterRequestDto request)
        {
            AppUser registeredUser = await _appUserManager.RegisterAsync(request);

            await _appUserManager.AssignRoleAsync(registeredUser, RolesEnum.User);

            string token = await _appUserManager.LogInAsync(registeredUser, request.Password);

            return Created(String.Empty, token);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<string>> Login([FromBody] AppUserLoginRequestDto request)
        {
            var token = await _appUserManager.LogInAsync(request);
            return Ok(token);
        }


    }
}
