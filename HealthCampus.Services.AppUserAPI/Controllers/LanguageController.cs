using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AppUserAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AppUserAPI.Controllers
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

        private readonly AppUserDbContext _dbContext;

        public LanguageController(AppUserDbContext AppUserDbContext)
        {
            _dbContext = AppUserDbContext;
            _response = new ResponseDto();
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<ResponseDto>> GetLanguages()
        {
            try
            {
                var languages = await _dbContext.Languages.ToListAsync();
                _response.Result = languages;
                return Ok(languages);
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return BadRequest(_response);
        }
    }
}
