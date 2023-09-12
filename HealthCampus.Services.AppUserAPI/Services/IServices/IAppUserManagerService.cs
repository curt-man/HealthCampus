using HealthCampus.CommonUtilities.Enums;
using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Models.Dtos;

namespace HealthCampus.Services.AppUserAPI.Services.IServices
{
    public interface IAppUserManagerService
    {
        Task AssignRoleTo(AppUser user, RolesEnum role);
        Task<AppUserResponseDto> Get(Guid appUserId);
        Task Delete(Guid appUserId);
        Task<string> LogIn(AppUser user, string password);
        Task<string> LogIn(AppUserLoginRequestDto request);
        Task<AppUser> Register<T>(T request) where T : IAppUserRegisterRequestDto;
        Task Update(AppUserUpdateRequestDto request);

    }
}