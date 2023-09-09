using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthCampus.Services.AppUserAPI.Models.Dto.Request
{
    public class AppUserLoginRequestDto
    {
        [Required]
        public string EmailOrUsername { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

    }
}
