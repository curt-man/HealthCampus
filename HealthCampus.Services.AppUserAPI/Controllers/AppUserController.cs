using HealthCampus.CommonUtilities.Dto;
using HealthCampus.CommonUtilities.Enums;
using HealthCampus.Services.AppUserAPI.Data;
using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Models.Dto.Request;
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
        public async Task<ActionResult<ResponseDto>> GetAppUsersAsync()
        {
            try
            {
                var users = await _dbContext.Users.ToListAsync();
                _response.Result = users;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return BadRequest(_response);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<ResponseDto>> CreateAsync([FromBody] AdminAppUserRegisterRequestDto request)
        {
            try
            { 
                AppUser registeredUser =
                    await _appUserManager.RegisterAppUser<AdminAppUserRegisterRequestDto>(request);

                await _appUserManager.AssignRoleToAppUser(registeredUser, request.AppRole);

                return Ok(_response);

            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return BadRequest(_response);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<ResponseDto>> UpdateAsync([FromBody] AppUserUpdateRequestDto request)
        {
            try
            {
                //AppUser registeredUser =
                //    await _appUserManager.UpdateAppUser<AppUserUpdateRequestDto>(request);

                //await _appUserManager.AssignRoleToAppUser(registeredUser, request.AppRole);

                return Ok(_response);

            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return BadRequest(_response);
        }


    }
}
