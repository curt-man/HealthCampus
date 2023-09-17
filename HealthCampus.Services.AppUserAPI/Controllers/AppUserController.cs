using HealthCampus.CommonUtilities.Dto;
using HealthCampus.CommonUtilities.Enums;
using HealthCampus.Services.AppUserAPI.Data;
using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Models.Dtos;
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
                var users = await _appUserManager.GetAll();
                _response.Result = users;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return BadRequest(_response);
        }

        [HttpGet]
        [Route("Get/Id/{id}")]
        public async Task<ActionResult<ResponseDto>> GetAsync(Guid id)
        {
            try
            {
                var user = await _appUserManager.Get(id);
                _response.Result = user;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return BadRequest(_response);
        }

        [HttpGet]
        [Route("Get/Username/{username}")]
        public async Task<ActionResult<ResponseDto>> GetAsync(string username)
        {
            try
            {
                var user = await _appUserManager.Get(username);
                _response.Result = user;
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
                AppUser registeredUser = await _appUserManager.Register(request);

                await _appUserManager.AssignRoleTo(registeredUser, request.AppRole);

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
                await _appUserManager.Update(request);

                return Ok(_response);

            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return BadRequest(_response);
        }

        [HttpGet]
        [Route("Delete/{appUserId}")]
        public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid appUserId)
        {
            try
            {
                await _appUserManager.Delete(appUserId);
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
