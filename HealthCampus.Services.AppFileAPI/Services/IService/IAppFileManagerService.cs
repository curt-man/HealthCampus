using HealthCampus.Services.AppFileAPI.Models.Dto;

namespace HealthCampus.Services.AppFileAPI.Services.IService
{
    public interface IAppFileManagerService
    {
        Task<List<AppFileResponseDto>> GetAppFilesAsync();
    }
}