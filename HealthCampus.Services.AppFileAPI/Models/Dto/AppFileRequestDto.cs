using HealthCampus.CommonUtilities;
using HealthCampus.CommonUtilities.Attributes;
using HealthCampus.Services.AppFileAPI.Utilities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthCampus.Services.AppFileAPI.Models.Dto
{
    public class AppFileRequestDto
    {
        [DefaultValue("studentdemostorage")]
        public string? StorageAccount { get; set; }
        [DefaultValue("profilepictures")]
        public string Container { get; set; }
        public Guid? BlobName { get; set; }
        [Required]
        [MaxFileSize(1024 * 10)]
        public IFormFile FormFile { get; set; }

    }


}
