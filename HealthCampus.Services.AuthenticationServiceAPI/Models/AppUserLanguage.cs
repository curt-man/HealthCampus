using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCampus.Services.AuthenticationServiceAPI.Models
{
    /// <summary>
    /// Model representing the language proficiency of a user.
    /// </summary>
    [PrimaryKey(nameof(AppUserId), nameof(LanguageId))]
    public class AppUserLanguage
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
        public byte LanguageId { get; set; }

        /// <summary>
        /// Reference to the language.
        /// </summary>
        public Language? Language { get; set; }

        /// <summary>
        /// The unique identifier of the language proficiency.
        /// </summary>
        [ForeignKey(nameof(Proficiency))]
        public byte ProficiencyId { get; set; }

        /// <summary>
        /// The proficiency level of the user in the language.
        /// </summary>
        public Proficiency? Proficiency { get; set; }
    }
}
