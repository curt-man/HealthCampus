using Azure;
using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AppUserAPI.Data;
using HealthCampus.Services.AppUserAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AppUserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly AppUserDbContext _dbContext;

        public GenderController(AppUserDbContext AppUserDbContext)
        {
            _dbContext = AppUserDbContext;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Gender>>> GetGenders()
        {
            var genders = await _dbContext.Genders.ToListAsync();
            return Ok(genders);
        }
    }
}
