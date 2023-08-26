using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthCampus.Services.AuthenticationServiceAPI.Models.Dto
{
    public class AppUserRegistrationRequestDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [PasswordPropertyText]
        [Required]
        public string Password { get; set; }

        public string AppRole { get; set; }
    }
}
