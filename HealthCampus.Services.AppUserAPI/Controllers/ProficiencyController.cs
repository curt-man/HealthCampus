using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AppUserAPI.Data;
using HealthCampus.Services.AppUserAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AppUserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProficiencyController : ControllerBase
    {
        private readonly AppUserDbContext _dbContext;

        public ProficiencyController(AppUserDbContext AppUserDbContext)
        {
            _dbContext = AppUserDbContext;
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Proficiency>>> GetProficiencies()
        {
            var proficiencies = await _dbContext.Proficiencies.ToListAsync();
            return Ok(proficiencies);
        }
    }
}
