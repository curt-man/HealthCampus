using Azure;
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

        private readonly IAppUserManagerService _appUserManager;

        public AppUserController(IAppUserManagerService appUserManager)
        {
            _appUserManager = appUserManager;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<AppUserResponseDto>>> GetAppUsers()
        {
            var users = await _appUserManager.GetAllAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("Get/Id/{id}")]
        public async Task<ActionResult<AppUserResponseDto>> Get(Guid id)
        {
            var user = await _appUserManager.GetAsync(id);
            return Ok(user);
        }

        [HttpGet]
        [Route("Get/Username/{username}")]
        public async Task<ActionResult<AppUserResponseDto>> Get(string username)
        {
            var user = await _appUserManager.GetAsync(username);
            return Ok(user);
        }


        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create([FromBody] AdminAppUserRegisterRequestDto request)
        {
            AppUser registeredUser = await _appUserManager.RegisterAsync(request);

            await _appUserManager.AssignRoleAsync(registeredUser, request.AppRole);

            return Created(String.Empty, null);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update([FromBody] AppUserUpdateRequestDto request)
        {
            await _appUserManager.UpdateAsync(request);
            return Ok();
        }

        [HttpGet]
        [Route("Delete/Id/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _appUserManager.DeleteAsync(id);
            return NoContent();
        }


        [HttpPost]
        [Route("AssignRole")]
        public async Task<ActionResult<ResponseDto>> AssignRole(AppUserAssignRoleRequestDto dto)
        {
            await _appUserManager.AssignRoleAsync(dto);
            return Ok();
        }

    }
}
