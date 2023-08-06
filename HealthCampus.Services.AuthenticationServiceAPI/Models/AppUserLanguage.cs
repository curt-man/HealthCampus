using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCampus.Services.AuthenticationServiceAPI.Models
{
    /// <summary>
    /// Model representing the language proficiency of a user.
    /// </summary>
    [PrimaryKey("LanguageId", "AppUserId")]
    public class AppUserLanguage
    {
        /// <summary>
        /// The unique identifier of the user.
        /// </summary>
        public virtual Guid AppUserId { get; set; }

        /// <summary>
        /// Reference to the user.
        /// </summary>
        public virtual AppUser? AppUser { get; set; }

        /// <summary>
        /// The unique identifier of the language.
        /// </summary>
        public virtual int LanguageId { get; set; }

        /// <summary>
        /// Reference to the language.
        /// </summary>
        public virtual Language? Language { get; set; }

        /// <summary>
        /// The proficiency level of the user in the language.
        /// </summary>
        [ForeignKey("ProficiencyId")]
        public Proficiency Proficiency { get; set; }

        /// <summary>
        /// The unique identifier of the language proficiency.
        /// </summary>
        public byte ProficiencyId { get; set; }
    }
}
