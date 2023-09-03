using HealthCampus.Services.AppUserAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCampus.Services.AppUserAPI.Models
{
    /// <summary>
    /// Model representing a language.
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Primary key of the language.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public LanguagesEnum Id { get; set; }

        /// <summary>
        /// The name of the language.
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// A collection of user language entities with a reference to their corresponding user and inverse property of "Language".
        /// </summary>
        public ICollection<AppUserLanguage>? AppUsers { get; set; }
    }
}
