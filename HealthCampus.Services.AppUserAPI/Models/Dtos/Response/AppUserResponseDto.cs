using HealthCampus.Services.AppUserAPI.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthCampus.Services.AppUserAPI.Models.Dto.Response
{
    public class AppUserResponseDto
    {
        /// <summary>
        /// The Id of the user.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The username of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The gender of the user.
        /// </summary>
        public GendersEnum? GenderId { get; set; }

        /// <summary>
        /// The unique identifier of user's profile picture.
        /// </summary>
        public Guid? ProfilePictureId { get; set; }

        public static AppUserResponseDto FromAppUser(AppUser model)
        {
            return new AppUserResponseDto()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                GenderId = model.GenderId,
                ProfilePictureId = model.ProfilePictureId
            };
        }
    }
}