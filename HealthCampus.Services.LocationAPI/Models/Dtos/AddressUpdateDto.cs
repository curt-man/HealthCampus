using HealthCampus.Services.LocationAPI.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCampus.Services.LocationAPI.Models.Dtos
{
    public class AddressUpdateDto
    {

        /// <summary>
        /// Unique identifier of the address.
        /// </summary>
        public Guid Id { get; set; }

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

    }
}
