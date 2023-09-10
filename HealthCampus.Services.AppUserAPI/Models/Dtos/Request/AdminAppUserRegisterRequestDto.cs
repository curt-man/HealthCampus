using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using HealthCampus.CommonUtilities.Enums;
using HealthCampus.Services.AppUserAPI.Enums;

namespace HealthCampus.Services.AppUserAPI.Models.Dto.Request
{
    public class AdminAppUserRegisterRequestDto : IAppUserRegisterRequestDto
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

        /// <summary>
        /// The second name of the user.
        /// </summary>
        [MaxLength(30)]
        public string? SecondName { get; set; }

        /// <summary>
        /// User's TIN (ИНН - идентификационный номер налогоплательщика) is unique identifier of a person.
        /// </summary>
        [MaxLength(14)]
        public string? TIN { get; set; }

        /// <summary>
        /// The date of birth of the user.
        /// </summary>
        public DateOnly? BirthDate { get; set; }

        /// <summary>
        /// The gender of the user.
        /// </summary>
        public GendersEnum? Gender { get; set; }

        public LanguagesEnum? Language { get; set; }

        public RolesEnum AppRole { get; set; }

        public string? PhoneNumber { get; set; }


        public AppUser ToAppUser(LanguagesEnum? userLanguage = null)
        {
            var appUserId = Guid.NewGuid();
            return new AppUser
            {
                Id = appUserId,
                FirstName = FirstName,
                LastName = LastName,
                Email = EmailAddress,
                UserName = EmailAddress,
                PhoneNumber = PhoneNumber,
                TIN = TIN,
                GenderId = Gender,
                BirthDate = BirthDate,
                RegisteredAt = DateTime.UtcNow,
                Languages = Language == null ? null : new List<AppUserLanguage>()
                {
                    new AppUserLanguage
                    {
                        AppUserId = appUserId,
                        LanguageId = Language ?? LanguagesEnum.English,
                        ProficiencyId = ProficienciesEnum.Native
                    }
                }
            };
        }
    }
}
