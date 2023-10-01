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
        public async Task<ActionResult<ResponseDto>> GetAppUsers()
        {
            try
            {
                var users = await _appUserManager.GetAllAsync();
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
        public async Task<ActionResult<ResponseDto>> Get(Guid id)
        {
            try
            {
                var user = await _appUserManager.GetAsync(id);
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
        public async Task<ActionResult<ResponseDto>> Get(string username)
        {
            try
            {
                var user = await _appUserManager.GetAsync(username);
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
        [Route("Create")]
        public async Task<ActionResult<ResponseDto>> Create([FromBody] AdminAppUserRegisterRequestDto request)
        {
            try
            {
                AppUser registeredUser = await _appUserManager.RegisterAsync(request);

                await _appUserManager.AssignRoleAsync(registeredUser, request.AppRole);

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
        public async Task<ActionResult<ResponseDto>> Update([FromBody] AppUserUpdateRequestDto request)
        {
            try
            {
                await _appUserManager.UpdateAsync(request);

                return Ok(_response);

            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return BadRequest(_response);
        }

        [HttpGet]
        [Route("Delete/Id/{id}")]
        public async Task<ActionResult<ResponseDto>> Delete(Guid id)
        {
            try
            {
                await _appUserManager.DeleteAsync(id);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return BadRequest(_response);
        }


        [HttpPost]
        [Route("AssignRole")]
        public async Task<ActionResult<ResponseDto>> AssignRole(AppUserAssignRoleRequestDto dto)
        {
            try
            {
                await _appUserManager.AssignRoleAsync(dto);

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
