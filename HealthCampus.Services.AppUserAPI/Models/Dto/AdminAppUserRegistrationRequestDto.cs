using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using HealthCampus.CommonUtilities.Enums;
using HealthCampus.Services.AppUserAPI.Enums;

namespace HealthCampus.Services.AppUserAPI.Models.Dto
{
    public class AdminAppUserRegistrationRequestDto : AppUserRegistrationRequestDto
    {

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

        public Address? Address { get; set; }

    }
}
