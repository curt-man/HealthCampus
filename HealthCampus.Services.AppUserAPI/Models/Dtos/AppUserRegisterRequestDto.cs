using HealthCampus.Services.AppUserAPI.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthCampus.Services.AppUserAPI.Models.Dtos
{
    public class AppUserRegisterRequestDto
    {
        /// <summary>
        /// The first name of the user.
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public string EmailAddress { get; set; }


        [Required]
        [DefaultValue("Welcome@123")]
        public string Password { get; set; }


    }
}
