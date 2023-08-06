using System.ComponentModel.DataAnnotations;

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
        [Key]
        public byte Id { get; set; }

        /// <summary>
        /// Name of the proficiency level.
        /// </summary>
        public string Name { get; set; }
    }
}
