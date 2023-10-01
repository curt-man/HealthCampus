namespace HealthCampus.Services.AppFileAPI.Models.Dto
{
    public class AppFileResponseDto
    {
        /// <summary>
        /// The unique identifier of the file in database, also name of the file in Azure Blob Storage.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The original name of the file.
        /// </summary>
        public string OriginalName { get; set; }

        /// <summary>
        /// The content type of the file.
        /// </summary>
        public FileContentType? ContentType { get; set; }

        /// <summary>
        /// The file size in kilobytes.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The duration of the file in seconds (if applicable).
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// The publicly accessible URL of the file.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The url to download the file (if applicable).
        /// </summary>
        public string? DownloadUrl { get; set; }

        /// <summary>
        /// The url of the thumbnail of the file (if applicable).
        /// </summary>
        public string? ThumbnailUrl { get; set; }

        public static AppFileResponseDto FromAppFile(AppFile appFile)
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
