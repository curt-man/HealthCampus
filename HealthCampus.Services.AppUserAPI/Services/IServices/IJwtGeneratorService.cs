using HealthCampus.CommonUtilities.Enums;
using HealthCampus.Services.AppUserAPI.Models;

namespace HealthCampus.Services.AppUserAPI.Services.IServices
{
    public interface IJwtGeneratorService
    {
        string GenerateToken(AppUser user, IEnumerable<string> roles);
    }
}