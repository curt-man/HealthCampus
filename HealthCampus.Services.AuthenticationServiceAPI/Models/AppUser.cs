using HealthCampus.Services.AppFileAPI.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCampus.Services.AuthenticationServiceAPI.Models
{
    /// <summary>
    /// Model representing a user in the application.
    /// </summary>
    public class AppUser : IdentityUser<Guid>
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

        /// <summary>
        /// The second name of the user.
        /// </summary>
        [MaxLength(30)]
        public string? SecondName { get; set; }

        /// <summary>
        /// User's INN (ИНН - идентификационный номер налогоплательщика) is unique identifier of a person in Kyrgyzstan.
        /// </summary>
        [StringLength(14)]
        public long? UserINN { get; set; }

        /// <summary>
        /// The date of birth of the user.
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// The gender of the user.
        /// </summary>
        public byte? GenderId { get; set; }

        [ForeignKey(nameof(GenderId))]
        public Gender? Gender { get; set; }

        /// <summary>
        /// The date of registration of the user.
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// The last date when the user was modified.
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// The last date when the user was modified.
        /// </summary>
        public DateTime? LastTimeOnlineDate { get; set; }

        /// <summary>
        /// The unique identifier of user's profile picture.
        /// </summary>
        public Guid? ProfilePictureId { get; set; }

        /// <summary>
        /// User's addresses.
        /// </summary>
        public ICollection<AppUserAddress>? Addresses { get; set; }

        /// <summary>
        /// User's languages.
        /// </summary>
        public ICollection<AppUserLanguage>? Languages { get; set; }

        

    }
}
