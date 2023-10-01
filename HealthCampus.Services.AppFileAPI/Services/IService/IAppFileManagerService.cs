using Azure.Storage.Blobs.Models;
using HealthCampus.Services.AppFileAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HealthCampus.Services.AppFileAPI.Services.IService
{
    public interface IAppFileManagerService
    {
        Task DeleteAsync(Guid appFileId, Guid appUserId);
        Task<FileContentResult?> DownloadAsync(Guid id);
        AppFileResponseDto Get(Guid appFileId);
        Task<List<AppFileResponseDto>> GetAllAsync();
        Task<Guid> UploadAsync(AppFileRequestDto dto, Guid appUserId);
    }
}