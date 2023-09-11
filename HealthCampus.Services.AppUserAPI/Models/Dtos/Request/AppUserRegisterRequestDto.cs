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
        


        public static AppUser ToAppUser<T>(T dto, LanguagesEnum? userLanguage = null) where T : IAppUserRegisterRequestDto
        {
            return ToAppUser(dto as AppUserRegisterRequestDto, userLanguage);
        }


        public static AppUser ToAppUser(AppUserRegisterRequestDto dto, LanguagesEnum? userLanguage = null)
        {
            return new AppUser()
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.EmailAddress,
                UserName = dto.EmailAddress,
                RegisteredAt = DateTime.UtcNow,
            };
        }


    }
}
