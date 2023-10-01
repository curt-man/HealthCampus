using HealthCampus.CommonUtilities.Enums;
using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Models.Dtos;

namespace HealthCampus.Services.AppUserAPI.Services.IServices
{
    public interface IAppUserManagerService
    {
        Task<List<AppUserResponseDto>> GetAllAsync();
        Task<AppUserResponseDto> GetAsync(Guid id);
        Task<AppUserResponseDto> GetAsync(string username);
        Task AssignRoleAsync(AppUserAssignRoleRequestDto dto);
        Task AssignRoleAsync(AppUser user, RolesEnum role);
        Task DeleteAsync(Guid appUserId);
        Task<string> LogInAsync(AppUser user, string password);
        Task<string> LogInAsync(AppUserLoginRequestDto request);
        Task<AppUser> RegisterAsync<T>(T request) where T : IAppUserRegisterRequestDto;
        Task UpdateAsync(AppUserUpdateRequestDto request);

    }
}