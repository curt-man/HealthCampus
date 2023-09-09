using HealthCampus.CommonUtilities.Enums;
using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Models.Dto.Request;

namespace HealthCampus.Services.AppUserAPI.Services.IServices
{
    public interface IAppUserManagerService
    {
        Task AssignRoleToAppUser(AppUser user, RolesEnum role);
        Task<string> LogInAppUser(AppUser user, string password);
        Task<string> LogInAppUser(AppUserLoginRequestDto request);
        Task<AppUser> RegisterAppUser<T>(T request) where T : AppUserRegisterRequestDto;
    }
}