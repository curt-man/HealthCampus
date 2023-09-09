using AutoMapper;
using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AppUserAPI.Data;
using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Models.Dto;
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
        private readonly IMapper _mapper;

        public AddressController(AppUserDbContext AppUserDbContext)
        {
            _dbContext = AppUserDbContext;
            _response = new ResponseDto();
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<ResponseDto>> GetAllAsync()
        {
            try
            {
                var addresses = await _dbContext.Addresses.ToListAsync();
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
        [Route("GetById/{id}")]
        public async Task<ActionResult<ResponseDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var address = await _dbContext.Addresses.FirstOrDefaultAsync(x => x.Id == id);
                if(address == null)
                {
                    return NotFound(_response);
                }
                var addressDto = _mapper.Map<AddressDto>(address);
                _response.Result = addressDto;
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
        public async Task<ActionResult<ResponseDto>> CreateAsync([FromBody] AddressDto addressDto)
        {
            try
            {
                var address = _mapper.Map<Address>(addressDto);
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
        public async Task<ActionResult<ResponseDto>> UpdateAsync([FromBody] AddressDto addressDto)
        {
            try
            {
                var address = _mapper.Map<Address>(addressDto);
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
        [Route("Delete/{id}")]
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