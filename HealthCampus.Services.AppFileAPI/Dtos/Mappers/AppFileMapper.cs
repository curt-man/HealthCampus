using HealthCampus.Services.AppFileAPI.Models;

namespace HealthCampus.Services.AppFileAPI.Dtos.Mappers
{
    public static class AppFileMapper
    {
        public static AppFileResponseDto ToAppFileResponseDto(this AppFile appFile)
        {
            var appFileDto = new AppFileResponseDto()
            {
                Id = appFile.Id,
                OriginalName = appFile.OriginalName,
                ContentType = appFile.ContentType,
                Size = appFile.Size,
                Duration = appFile.Duration,
                Url = appFile.Url,
                DownloadUrl = appFile.DownloadUrl,
                ThumbnailUrl = appFile.ThumbnailUrl
            };
            return appFileDto;
        }

        
    }
}
