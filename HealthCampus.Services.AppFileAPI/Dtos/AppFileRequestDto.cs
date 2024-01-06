using HealthCampus.CommonUtilities;
using HealthCampus.CommonUtilities.Attributes;
using HealthCampus.Services.AppFileAPI.Utilities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthCampus.Services.AppFileAPI.Dtos
{
    public class AppFileRequestDto
    {

        [DefaultValue("profilepictures")]
        public string BlobContainer { get; set; }
        public Guid? BlobName { get; set; }
        [Required]
        [MaxFileSize(1024 * 10)]
        public IFormFile FormFile { get; set; }

    }


}
