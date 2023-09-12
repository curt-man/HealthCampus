using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using HealthCampus.CommonUtilities.Enums;
using HealthCampus.Services.AppUserAPI.Enums;

namespace HealthCampus.Services.AppUserAPI.Models.Dtos
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

        public static AppUser ToAppUser<T>(T dto, LanguagesEnum? userLanguage = null) where T : IAppUserRegisterRequestDto
        {
            return ToAppUser(dto as AdminAppUserRegisterRequestDto, userLanguage);
        }

        public static AppUser ToAppUser(AdminAppUserRegisterRequestDto dto, LanguagesEnum? userLanguage = null)
        {
            var appUserId = Guid.NewGuid();
            return new AppUser
            {
                Id = appUserId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.EmailAddress,
                UserName = dto.EmailAddress,
                PhoneNumber = dto.PhoneNumber,
                TIN = dto.TIN,
                GenderId = dto.Gender,
                BirthDate = dto.BirthDate,
                RegisteredAt = DateTime.UtcNow,
                Languages = dto.Language == null ? null : new List<AppUserLanguage>()
                {
                    new AppUserLanguage
                    {
                        AppUserId = appUserId,
                        LanguageId = dto.Language ?? LanguagesEnum.English,
                        ProficiencyId = ProficienciesEnum.Native
                    }
                }
            };
        }
    }
}
