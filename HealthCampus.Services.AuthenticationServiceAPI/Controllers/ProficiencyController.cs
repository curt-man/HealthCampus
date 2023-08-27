using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AuthenticationServiceAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AuthenticationServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProficiencyController : ControllerBase
    {
        private readonly ResponseDto _response;

        private void SetErrorMessageToResponse(string message)
        {
            _response.IsSuccess = false;
            _response.Message = message;
        }

        private readonly AuthenticationDbContext _dbContext;

        public ProficiencyController(AuthenticationDbContext authenticationDbContext)
        {
            _dbContext = authenticationDbContext;
            _response = new ResponseDto();
        }


        [HttpGet]
        [Route("GetProficiencies")]
        public async Task<ActionResult<ResponseDto>> GetProficienciesAsync()
        {
            try
            {
                var proficiencies = await _dbContext.Proficiencies.ToListAsync();
                _response.Result = proficiencies;
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return Ok(_response);
        }
    }
}
