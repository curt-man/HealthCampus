using HealthCampus.Services.AppUserAPI.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCampus.Services.AppUserAPI.Models
{
    /// <summary>
    /// Model representing the language proficiency of a user.
    /// </summary>
    [PrimaryKey(nameof(AppUserId), nameof(UserStatusId))]
    public class AppUserUserStatus
    {
        /// <summary>
        /// The unique identifier of the user.
        /// </summary>
        [Column(Order = 1)]
        public Guid AppUserId { get; set; }

        /// <summary>
        /// Reference to the user.
        /// </summary>
        public AppUser? AppUser { get; set; }

        /// <summary>
        /// The unique identifier of the language.
        /// </summary>
        [Column(Order = 2)]
        public UserStatusesEnum UserStatusId { get; set; }

        /// <summary>
        /// Reference to the language.
        /// </summary>
        public UserStatus? UserStatus { get; set; }

        /// <summary>
        /// The last date when the user was modified.
        /// </summary>
        public DateTime? LastTimeOnlineAt { get; set; }


    }
}
