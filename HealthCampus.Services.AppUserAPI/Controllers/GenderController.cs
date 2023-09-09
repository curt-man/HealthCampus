using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AppUserAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AppUserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly ResponseDto _response;

        private void SetErrorMessageToResponse(string message)
        {
            _response.IsSuccess = false;
            _response.Message = message;
        }

        private readonly AppUserDbContext _dbContext;

        public GenderController(AppUserDbContext AppUserDbContext)
        {
            _dbContext = AppUserDbContext;
            _response = new ResponseDto();
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<ResponseDto>> GetGendersAsync()
        {
            try
            {
                var genders = await _dbContext.Genders.ToListAsync();
                _response.Result = genders;
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
