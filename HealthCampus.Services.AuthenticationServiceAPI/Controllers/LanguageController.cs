using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AuthenticationServiceAPI.Data;
using HealthCampus.Services.AuthenticationServiceAPI.Models;
using HealthCampus.Services.AuthenticationServiceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AuthenticationServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ResponseDto _response;

        private void SetErrorMessageToResponse(string message)
        {
            _response.IsSuccess = false;
            _response.Message = message;
        }

        private readonly AuthenticationDbContext _dbContext;

        public LanguageController(AuthenticationDbContext authenticationDbContext)
        {
            _dbContext = authenticationDbContext;
            _response = new ResponseDto();
        }


        [HttpGet]
        [Route("GetLanguages")]
        public async Task<ActionResult<ResponseDto>> GetLanguagesAsync()
        {
            try
            {
                var languages = await _dbContext.Languages.ToListAsync();
                _response.Result = languages;
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return Ok(_response);
        }
    }
}
