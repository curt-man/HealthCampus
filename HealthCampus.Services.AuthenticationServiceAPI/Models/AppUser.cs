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
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The second name of the user.
        /// </summary>
        public string? SecondName { get; set; }

        /// <summary>
        /// User's INN (ИНН - идентификационный номер налогоплательщика) is unique identifier of a person in Kyrgyzstan.
        /// </summary>
        public long? UserINN { get; set; }

        /// <summary>
        /// The date of birth of the user.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// The sex of the user.
        /// </summary>
        public byte Sex { get; set; }

        /// <summary>
        /// The date of registration of the user.
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// The last date when the user was modified.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// The unique identifier of user's profile picture.
        /// </summary>
        [ForeignKey(nameof(ProfilePicture))]
        public Guid? ProfilePictureId { get; set; }

        /// <summary>
        /// User's profile picture.
        /// </summary>
        [NotMapped]
        public AppFile? ProfilePicture { get; set; }

        /// <summary>
        /// User's addresses.
        /// </summary>
        public ICollection<AppUserAddress>? Addresses { get; set; }

        /// <summary>
        /// User's languages.
        /// </summary>
        public ICollection<AppUserLanguage>? Languages { get; set; }

        /// <summary>
        /// The identifier of user's status.
        /// </summary>
        public byte AppUserStatusId { get; set; }

        /// <summary>
        /// The status of the user.
        /// </summary>
        public AppUserStatus? AppUserStatus { get; set; }

    }
}
