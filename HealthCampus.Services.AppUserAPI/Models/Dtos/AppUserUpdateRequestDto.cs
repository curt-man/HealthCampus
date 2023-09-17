using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using HealthCampus.CommonUtilities.Enums;
using HealthCampus.Services.AppUserAPI.Enums;

namespace HealthCampus.Services.AppUserAPI.Models.Dtos
{
    public class AppUserUpdateRequestDto
    {
        /// <summary>
        /// The Id of the user.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The first name of the user.
        /// </summary>
        [MaxLength(30)]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        [MaxLength(30)]
        public string LastName { get; set; }

        /// <summary>
        /// The second name of the user.
        /// </summary>
        [MaxLength(30)]
        public string? SecondName { get; set; }

        /// <summary>
        /// User's TIN (ИНН - идентификационный номер налогоплательщика) is unique identifier of a person.
        /// </summary>
        [MaxLength(14)]
        public string? TIN { get; set; }

        /// <summary>
        /// The date of birth of the user.
        /// </summary>
        public DateOnly? BirthDate { get; set; }

        /// <summary>
        /// The gender of the user.
        /// </summary>
        public GendersEnum? Gender { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }


        public static AppUser ToAppUser(AppUserUpdateRequestDto dto)
        {
            return new AppUser
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                SecondName = dto.SecondName,
                PhoneNumber = dto.PhoneNumber,
                TIN = dto.TIN,
                GenderId = dto.Gender,
                BirthDate = dto.BirthDate,
                ModifiedAt = DateTime.UtcNow
            };
        }


        public static void MapToAppUser(AppUserUpdateRequestDto dto, AppUser model)
        {
            model.Id = dto.Id;
            model.FirstName = dto.FirstName;
            model.LastName = dto.LastName;
            model.SecondName = dto.SecondName;
            model.PhoneNumber = dto.PhoneNumber;
            model.TIN = dto.TIN;
            model.GenderId = dto.Gender;
            model.BirthDate = dto.BirthDate;
            model.ModifiedAt = DateTime.UtcNow;
        }
    }
}
