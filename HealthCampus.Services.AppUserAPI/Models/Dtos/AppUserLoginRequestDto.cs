using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthCampus.Services.AppUserAPI.Models.Dtos
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
