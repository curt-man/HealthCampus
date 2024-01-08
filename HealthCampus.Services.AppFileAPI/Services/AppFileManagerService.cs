using AutoMapper;
using Azure;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using HealthCampus.CommonUtilities.Dto;
using HealthCampus.CommonUtilities.Exceptions;
using HealthCampus.Services.AppFileAPI.Controllers;
using HealthCampus.Services.AppFileAPI.Data;
using HealthCampus.Services.AppFileAPI.Dtos;
using HealthCampus.Services.AppFileAPI.Dtos.Mappers;
using HealthCampus.Services.AppFileAPI.Models;
using HealthCampus.Services.AppFileAPI.Services.IService;
using HealthCampus.Services.AppFileAPI.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AppFileAPI.Services
{
    public class AppFileManagerService : IAppFileManagerService
    {
        private readonly IBlobService _blobService;
        private readonly IMediaService _mediaService;
        private readonly ILogger<AppFileController> _logger;
        private readonly AppFileDbContext _dbContext;

        public AppFileManagerService(IBlobService blobService, IMediaService mediaService, ILogger<AppFileController> logger, AppFileDbContext dbContext)
        {
            _blobService = blobService;
            _mediaService = mediaService;
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<List<AppFileResponseDto>> GetAllAsync()
        {
            var appFiles = new List<AppFileResponseDto>();
            await foreach (var appFile in _dbContext.AppFiles.AsAsyncEnumerable())
            {
                appFiles.Add(appFile.ToAppFileResponseDto());
            }
            return appFiles;
        }

        public async Task<AppFileResponseDto> GetAsync(Guid appFileId)
        {
            var appFile = await _dbContext.AppFiles.FirstOrDefaultAsync(x => x.Id == appFileId);

            if (appFile == null)
                throw new NotFoundException("File not found");

            var dto = appFile.ToAppFileResponseDto();

            return dto;
        }

        public async Task<Guid> UploadAsync(AppFileRequestDto dto, Guid appUserId)
        {
            if (dto == null)
                throw new BadRequestException("Invalid dto");

            AppFile? appFile;

            IFormFile file = dto.FormFile;
            if (file == null || file.Length == 0)
                throw new BadRequestException("File is not attached");

            Guid appFileGuid;
            if (dto.BlobName == null)
            {
                appFileGuid = Guid.NewGuid();
                appFile = new AppFile()
                {
                    Id = appFileGuid,
                    UploadedAt = DateTime.UtcNow,
                    UploadedByUserId = appUserId
                };
            }
            else
            {
                appFileGuid = dto.BlobName.Value;
                appFile = _dbContext.AppFiles.FirstOrDefault(x => x.Id == dto.BlobName);
                if (appFile == null)
                {
                    throw new NotFoundException("File not found");
                }
                else
                {
                    appFile.ModifiedAt = DateTime.UtcNow;
                    appFile.ModifiedByUserId = appUserId;
                }

            }

            int fileSize = Convert.ToInt32(file.Length / 1024L);
            string fileOriginalName = file.FileName;
            string fileExtension = Path.GetExtension(file.FileName);

            FileContentType? fileContentType = _dbContext.FileContentTypes.FirstOrDefault(x => x.Extension == fileExtension);
            if (fileContentType == null)
            {
                throw new BadRequestException("File extension is not supported");
            }

            if (fileContentType.MediaType == MediaType.Audio || fileContentType.MediaType == MediaType.Video)
            {
                using (var stream = file.OpenReadStream())
                {
                    int fileDuration = _mediaService.GetMediaFileDuration(stream);
                    appFile.Duration = fileDuration;
                }
            }

            // It should compress image but it's not working
            //if (fileContentType.MediaType == MediaType.Image)
            //{
            //    using (Stream compressedImage = _mediaService.CompressImage(file.OpenReadStream()))
            //    {
            //        await _blobService.UploadFileBlobAsync(appFileGuid.ToString(), compressedImage, file.ContentType, request.BlobContainer);
            //        appFile.ThumbnailUrl = $"https://studentdemostorage.blob.core.windows.net/{request.BlobContainer}/{appFileGuid}.thumbnail";
            //    }
            //}

            await _blobService.UploadFileBlobAsync(appFileGuid.ToString(), file.OpenReadStream(), file.ContentType, dto.BlobContainer);
            appFile.Url = $"https://studentdemostorage.blob.core.windows.net/{dto.BlobContainer}/{appFileGuid}";

            appFile.BlobContainer = dto.BlobContainer;
            appFile.ContentTypeId = fileContentType.Id;
            appFile.OriginalName = fileOriginalName;
            appFile.Size = fileSize;

            if (dto.BlobName == null)
            {
                await _dbContext.AppFiles.AddAsync(appFile);
            }
            else
            {
                _dbContext.AppFiles.Update(appFile);
            }
            await _dbContext.SaveChangesAsync();

            return appFileGuid;
        }



        public async Task DeleteAsync(Guid appFileId, Guid appUserId)
        {
            var appFile = _dbContext.AppFiles.FirstOrDefault(x=>x.Id == appFileId);
            if (appFile == null)
                throw new NotFoundException("File not found");

            await _blobService.DeleteBlobAsync(appFile.Id.ToString(), appFile.BlobContainer);

            _dbContext.AppFiles.Remove(appFile);

            await _dbContext.SaveChangesAsync();

        }

        public async Task<FileContentResult?> DownloadAsync(Guid id)
        {
            var appFile = _dbContext.AppFiles.FirstOrDefault(x => x.Id == id);
            if (appFile == null)
                throw new NotFoundException("File not found");

            var blob = await _blobService.GetBlobAsync(appFile.Id.ToString(), appFile.BlobContainer);

            FileContentResult file = new FileContentResult(blob.Content.ToArray(), blob.Details.ContentType);
            file.FileDownloadName = appFile.OriginalName;
            file.LastModified = appFile.ModifiedAt;

            return file;
        }

    }
}
