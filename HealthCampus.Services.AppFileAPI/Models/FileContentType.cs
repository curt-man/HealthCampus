using System.ComponentModel.DataAnnotations;

namespace HealthCampus.Services.AppFileAPI.Models
{
    /// <summary>
    /// Represents a file content type.
    /// </summary>
    public class FileContentType
    {
        /// <summary>
        /// The primary key for the content type.
        /// </summary>
        public byte Id { get; set; }

        /// <summary>
        /// The media type for the content type; e.g., "image", "video", "application", etc.
        /// </summary>
        public string MediaType { get; set; }

        /// <summary>
        /// The sub-type for the content type; e.g., "jpeg", "png", "mp4", "pdf", etc.
        /// </summary>
        public string SubType { get; set; }

        /// <summary>
        /// The extension for the content type.
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// The optional human-readable description for the content type; e.g., "JPEG image files".
        /// </summary>
        public string Description { get; set; }

    }
}

