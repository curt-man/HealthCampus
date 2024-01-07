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
    public class UserStatusController : ControllerBase
    {
        private readonly AppUserDbContext _dbContext;

        public UserStatusController(AppUserDbContext AppUserDbContext)
        {
            _dbContext = AppUserDbContext;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<UserStatus>>> GetUsersStatuses()
        {
            var usersStatuses = await _dbContext.UserStatuses.ToListAsync();
            return Ok(usersStatuses);
        }
    }
}
