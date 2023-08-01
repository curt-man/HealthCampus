using HealthCampus.Services.AppFileAPI.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace HealthCampus.Services.AppFileAPI.Models
{
    /// <summary>
    /// Represents a file of the application that stored in database.
    /// </summary>
    public class AppFile
    {
        /// <summary>
        /// The unique identifier of the file, also a name.
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// The container in which the blob is stored.
        /// </summary>
        [Required]
        public string BlobContainer { get; set; }

        /// <summary>
        /// The original name of the file.
        /// </summary>
        [Required]
        public string OriginalName { get; set; }

        /// <summary>
        /// The ID of the content type of the file.
        /// </summary>
        [Required]
        public byte ContentTypeId { get; set; }
        /// <summary>
        /// The content type of the file.
        /// </summary>
        [ForeignKey("ContentTypeId")]
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

        /// <summary>
        /// The date the file was uploaded.
        /// </summary>
        [Required]
        public DateTime UploadedDate { get; set; }
        /// <summary>
        /// The date the file was last modified (if applicable).
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// The unique identifier of the user who uploaded the file.
        /// </summary>
        [Required]
        public Guid UploadedByUserId { get; set; }
        /// <summary>
        /// The unique identifier of the user who last modified the file (if applicable).
        /// </summary>
        public Guid? ModifiedByUserId { get; set; }
        /// <summary>
        /// Whether the file is publicly accessible.
        /// </summary>
        public bool? IsPublic { get; set; }
    }

}
