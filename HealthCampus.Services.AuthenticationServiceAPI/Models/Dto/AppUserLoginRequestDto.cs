using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthCampus.Services.AuthenticationServiceAPI.Models.Dto
{
    public class AppUserLoginRequestDto
    {
        [Required]
        public string EmailOrLogin { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

    }
}
