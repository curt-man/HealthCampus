using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AppUserAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AppUserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppRoleController : ControllerBase
    {
        private readonly ResponseDto _response;

        private void SetErrorMessageToResponse(string message)
        {
            _response.IsSuccess = false;
            _response.Message = message;
        }

        private readonly AppUserDbContext _dbContext;

        public AppRoleController(AppUserDbContext AppUserDbContext)
        {
            _response = new ResponseDto();
            _dbContext = AppUserDbContext;
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<ResponseDto>> GetAppRolesAsync()
        {
            try
            {
                var roles = await _dbContext.Roles.ToListAsync();
                _response.Result = roles;
                return Ok(roles);
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return BadRequest(_response);
        }
    }
}
