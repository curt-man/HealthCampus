using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AppUserAPI.Data;
using HealthCampus.Services.AppUserAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AppUserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppUserDbContext _dbContext;

        public LanguageController(AppUserDbContext AppUserDbContext)
        {
            _dbContext = AppUserDbContext;
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Language>>> GetLanguages()
        {
            var languages = await _dbContext.Languages.ToListAsync();
            return Ok(languages);

        }
    }
}
