using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AuthenticationServiceAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AuthenticationServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStatusController : ControllerBase
    {
        private readonly ResponseDto _response;

        private void SetErrorMessageToResponse(string message)
        {
            _response.IsSuccess = false;
            _response.Message = message;
        }

        private readonly AuthenticationDbContext _dbContext;

        public UserStatusController(AuthenticationDbContext authenticationDbContext)
        {
            _dbContext = authenticationDbContext;
            _response = new ResponseDto();
        }


        [HttpGet]
        [Route("GetUserStatus")]
        public async Task<ActionResult<ResponseDto>> GetUserStatusAsync()
        {
            try
            {
                var userStatus = await _dbContext.UserStatuses.ToListAsync();
                _response.Result = userStatus;
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return Ok(_response);
        }
    }
}
