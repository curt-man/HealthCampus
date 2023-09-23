using HealthCampus.CommonUtilities.Dto;
using HealthCampus.CommonUtilities.Enums;
using HealthCampus.CommonUtilities.Utilities;
using HealthCampus.Services.LocationAPI.Data;
using HealthCampus.Services.LocationAPI.Models;
using HealthCampus.Services.LocationAPI.Models.Dtos;
using HealthCampus.Services.LocationAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HealthCampus.Services.LocationAPI.Controllers
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

        private readonly LocationDbContext _dbContext;

        public AddressController(LocationDbContext dbContext)
        {
            _dbContext = dbContext;
            _response = new ResponseDto();
        }


        [HttpGet]
        [Route("")]
        [Authorize(Policy = AccessPolicy.Indigo)]
        public async Task<ActionResult<ResponseDto>> GetAddressesAsync()
        {
            try
            {
                List<AddressResponseDto> addresses = await AddressResponseDto.FromAddressQueryableAsync(_dbContext.Addresses);
                _response.Result = addresses;
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
        [Authorize]
        public async Task<ActionResult<ResponseDto>> GetAsync(Guid id)
        {
            try
            {
                var address = await _dbContext.Addresses.FirstOrDefaultAsync(x => x.Id == id);
                if(address == null)
                {
                    return NotFound(_response);
                }
                var dto = AddressResponseDto.FromAddress(address);
                _response.Result = dto;
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
        public async Task<ActionResult<ResponseDto>> CreateAsync([FromBody] AddressCreateDto dto)
        {
            try
            {
                var address = AddressCreateDto.ToAddress(dto);
                await _dbContext.Addresses.AddAsync(address);
                await _dbContext.SaveChangesAsync();
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
        public async Task<ActionResult<ResponseDto>> UpdateAsync([FromBody] AddressUpdateDto dto)
        {
            try
            {
                var address = AddressUpdateDto.ToAddress(dto);
                _dbContext.Addresses.Update(address);
                await _dbContext.SaveChangesAsync();
                return Ok(_response);
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return BadRequest(_response);
        }

        [HttpDelete]
        [Route("Delete/Id/{id}")]
        public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id)
        {
            try
            {
                var address = await _dbContext.Addresses.FirstOrDefaultAsync(x => x.Id == id);
                if(address == null)
                {
                    return NotFound(_response);
                }
                _dbContext.Addresses.Remove(address);
                await _dbContext.SaveChangesAsync();
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




