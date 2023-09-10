using HealthCampus.Services.LocationAPI.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCampus.Services.LocationAPI.Models.Dtos
{
    /// <summary>
    /// DTO representing a new address.
    /// </summary>
    public class AddressCreateDto
    {

        /// <summary>
        /// City of the address.
        /// </summary>
        [MaxLength(50)]
        public string City { get; set; }

        /// <summary>
        /// Street of the address.
        /// </summary>
        [MaxLength(50)]
        public string Street { get; set; }

        /// <summary>
        /// House number of the address.
        /// </summary>
        [MaxLength(50)]
        public string HouseNumber { get; set; }

        /// <summary>
        /// Flat number of the address.
        /// </summary>
        [MaxLength(50)]
        public string FlatNumber { get; set; }

        /// <summary>
        /// Zip code of the address.
        /// </summary>
        [StringLength(6)]
        public string ZipCode { get; set; }

        public static Address ToAddress(AddressCreateDto dto)
        {
            return new Address()
            {
                Id = Guid.NewGuid(),
                City = dto.City,
                Street = dto.Street,
                HouseNumber = dto.HouseNumber,
                FlatNumber = dto.FlatNumber,
                ZipCode = dto.ZipCode
            };
        }

        public static AppUserAddress ToAppUserAddress(AddressCreateDto dto, Guid appUserId)
        {
            var address =
                new AppUserAddress()
                {
                    Address = ToAddress(dto),
                    AppUserId = appUserId,
                    IsMainAddress = true
                };
            return address;
        }
    }
}
