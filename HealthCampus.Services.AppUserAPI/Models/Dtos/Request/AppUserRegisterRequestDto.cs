using HealthCampus.Services.AppUserAPI.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthCampus.Services.AppUserAPI.Models.Dto.Request
{
    public class AppUserRegisterRequestDto : IAppUserRegisterRequestDto
    {
        /// <summary>
        /// The first name of the user.
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public string EmailAddress { get; set; }


        [Required]
        [DefaultValue("Welcome@123")]
        public string Password { get; set; }


        public AppUser ToAppUser(LanguagesEnum? userLanguage = null)
        {
            return new AppUser()
            {
                Id = Guid.NewGuid(),
                FirstName = FirstName,
                LastName = LastName,
                Email = EmailAddress,
                UserName = EmailAddress,
                RegisteredAt = DateTime.UtcNow,
            };
        }

        
    }
}
