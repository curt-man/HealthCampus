using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AuthenticationServiceAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AuthenticationServiceAPI.Controllers
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

        private readonly AuthenticationDbContext _dbContext;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public AppRoleController(AuthenticationDbContext authenticationDbContext, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _response = new ResponseDto();
            _dbContext = authenticationDbContext;
            _roleManager = roleManager;
        }


        [HttpGet]
        [Route("GetAppRoles")]
        public async Task<ActionResult<ResponseDto>> GetAppRolesAsync()
        {
            try
            {
                var addresses = await _roleManager.Roles.ToListAsync();
                _response.Result = addresses;
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return Ok(_response);
        }
    }
}
