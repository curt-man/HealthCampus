using Azure.Storage.Blobs.Models;
using HealthCampus.Services.AppFileAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HealthCampus.Services.AppFileAPI.Services.IService
{
    public interface IAppFileManagerService
    {
        Task DeleteAsync(Guid appFileId, Guid appUserId);
        Task<FileContentResult?> DownloadAsync(Guid id);
        Task<AppFileResponseDto> GetAsync(Guid appFileId);
        Task<List<AppFileResponseDto>> GetAllAsync();
        Task<Guid> UploadAsync(AppFileRequestDto dto, Guid appUserId);
    }
}