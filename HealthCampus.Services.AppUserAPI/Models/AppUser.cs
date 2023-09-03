using HealthCampus.Services.AppUserAPI.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCampus.Services.AppUserAPI.Models
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
        /// User's TIN (ИНН - идентификационный номер налогоплательщика) is unique identifier of a tax payer.
        /// </summary>
        [StringLength(14)]
        public string? TIN { get; set; }

        /// <summary>
        /// The date of birth of the user.
        /// </summary>
        public DateOnly? BirthDate { get; set; }

        /// <summary>
        /// The gender of the user.
        /// </summary>
        [ForeignKey(nameof(GenderId))]
        public GendersEnum? GenderId { get; set; }

        //public Gender? Gender { get; set; }

        /// <summary>
        /// The date of registration of the user.
        /// </summary>
        public DateTime RegisteredAt { get; set; }

        /// <summary>
        /// The last date when the user was modified.
        /// </summary>
        public DateTime? ModifiedAt { get; set; }

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
