using HealthCampus.CommonUtilities.Dto;
using HealthCampus.CommonUtilities.Exceptions;
using HealthCampus.CommonUtilities.Utilities;
using HealthCampus.Services.LocationAPI.Data;
using HealthCampus.Services.LocationAPI.Models;
using HealthCampus.Services.LocationAPI.Models.Dtos;
using HealthCampus.Services.LocationAPI.Models.Dtos.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.LocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private readonly LocationDbContext _dbContext;

        public AddressController(LocationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        [Route("")]
        [Authorize(Policy = AccessPolicy.Indigo)]
        public async Task<ActionResult<List<AddressResponseDto>>> GetAddresses()
        {
            List<AddressResponseDto> addresses = await _dbContext.Addresses.ToAddressResponseDtoListAsync();
            return Ok(addresses);
        }

        [HttpGet]
        [Route("Get/Id/{id}")]
        [Authorize]
        public async Task<ActionResult<AddressResponseDto>> Get(Guid id)
        {
            var address = await _dbContext.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (address == null)
            {
                throw new NotFoundException("Address not found");
            }
            var dto = address.ToAddressResponseDto();
            return Ok(dto);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create([FromBody] AddressCreateDto dto)
        {
            var address = dto.ToAddress();
            await _dbContext.Addresses.AddAsync(address);
            await _dbContext.SaveChangesAsync();
            return Created(String.Empty, null);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update([FromBody] AddressUpdateDto dto)
        {
            var address = dto.ToAddress();
            _dbContext.Addresses.Update(address);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/Id/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var address = await _dbContext.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (address == null)
            {
                throw new NotFoundException("Address not found");
            }
            _dbContext.Addresses.Remove(address);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}




