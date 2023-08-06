using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCampus.Services.AuthenticationServiceAPI.Models
{
    /// <summary>
    /// Model representing a language.
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Primary key of the language.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of the language.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A collection of user language entities with a reference to their corresponding user and inverse property of "Language".
        /// </summary>
        [InverseProperty("Language")]
        public ICollection<AppUserLanguage>? AppUsers { get; set; }
    }
}
