using Azure;
using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AppUserAPI.Data;
using HealthCampus.Services.AppUserAPI.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AppUserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppRoleController : ControllerBase
    {
        private readonly AppUserDbContext _dbContext;

        public AppRoleController(AppUserDbContext AppUserDbContext)
        {
            _dbContext = AppUserDbContext;
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<IdentityRole<Guid>>>> GetAppRoles()
        {
            var roles = await _dbContext.Roles.ToListAsync();
            return roles;
        }

        [HttpGet]
        [Route("Get/Id/{id}")]
        public async Task<ActionResult<IdentityRole<Guid>>> Get(Guid id)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
            return role;
        }

        
    }
}
    