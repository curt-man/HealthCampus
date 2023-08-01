using HealthCampus.Services.AppFileAPI.Utilities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthCampus.Services.AppFileAPI.Models.Dto
{
    public class AppFileRequestDto
    {
        [DefaultValue("ce5776b7-b67a-4ece-8000-7edc1e7bfb37")]
        public Guid UserId { get; set; }
        [DefaultValue("studentdemostorage")]
        public string? StorageAccount { get; set; }
        [DefaultValue("profilepictures")]
        public string Container { get; set; }
        public Guid? BlobName { get; set; }
        [Required]
        [MaxFileSize(1024*10)]
        public IFormFile FormFile { get; set; }

    }


}
