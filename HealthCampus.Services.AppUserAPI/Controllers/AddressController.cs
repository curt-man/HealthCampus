using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AppUserAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AppUserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ResponseDto _response;

        private void SetErrorMessageToResponse(string message)
        {
            _response.IsSuccess = false;
            _response.Message = message;
        }

        private readonly AppUserDbContext _dbContext;

        public AddressController(AppUserDbContext AppUserDbContext)
        {
            _dbContext = AppUserDbContext;
            _response = new ResponseDto();
        }


        [HttpGet]
        [Route("GetAddresses")]
        public async Task<ActionResult<ResponseDto>> GetAddressesAsync()
        {
            try
            {
                var addresses = await _dbContext.Addresses.ToListAsync();
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