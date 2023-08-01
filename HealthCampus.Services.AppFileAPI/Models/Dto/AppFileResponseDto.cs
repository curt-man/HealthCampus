using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCampus.Services.AppFileAPI.Models.Dto
{
    public class AppFileResponseDto
    {
        /// <summary>
        /// The original name of the file.
        /// </summary>
        [Required]
        public string OriginalName { get; set; }

        /// <summary>
        /// The content type of the file.
        /// </summary>
        public FileContentType? ContentType { get; set; }

        /// <summary>
        /// The file size in kilobytes.
        /// </summary>
        [Required]
        public int Size { get; set; }

        /// <summary>
        /// The duration of the file in seconds (if applicable).
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// The publicly accessible URL of the file.
        /// </summary>
        [Required]
        public string Url { get; set; }

        /// <summary>
        /// The url to download the file (if applicable).
        /// </summary>
        public string? DownloadUrl { get; set; }

        /// <summary>
        /// The url of the thumbnail of the file (if applicable).
        /// </summary>
        public string? ThumbnailUrl { get; set; }

    }
}
