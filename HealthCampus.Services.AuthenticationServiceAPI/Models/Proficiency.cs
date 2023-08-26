using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCampus.Services.AuthenticationServiceAPI.Models
{
    /// <summary>
    /// Model for proficiency of a user in a language.
    /// </summary>
    public class Proficiency
    {
        /// <summary>
        /// Unique identifier for a user's language proficiency.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        /// <summary>
        /// Name of the proficiency level.
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
