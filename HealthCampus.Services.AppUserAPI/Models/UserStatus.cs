using HealthCampus.Services.AppUserAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCampus.Services.AppUserAPI.Models
{
    /// <summary>
    /// Model representing a user status.
    /// </summary>
    public class UserStatus
    {
        /// <summary>
        /// The unique identifier of the user status.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public UserStatusesEnum Id { get; set; }

        /// <summary>
        /// The status of the user.
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// The description of the user status.
        /// </summary>
        [MaxLength(250)]
        public string Description { get; set; }
    }
}