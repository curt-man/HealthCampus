using HealthCampus.Services.AppUserAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCampus.Services.AppUserAPI.Models
{
    public class Gender
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public GendersEnum Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
