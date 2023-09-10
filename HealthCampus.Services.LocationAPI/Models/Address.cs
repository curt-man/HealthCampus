using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCampus.Services.LocationAPI.Models
{
    /// <summary>
    /// Model representing an address of user, pharmacy, company.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Unique identifier of the address.
        /// </summary>
        [Key]
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

        /// <summary>
        /// Date and time of creation of the address.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The last date when the address was modified.
        /// </summary>
        public DateTime? ModifiedAt { get; set; }

        /// <summary>
        /// Collection of users that use this address.
        /// </summary>
        [JsonIgnore]
        public ICollection<AppUserAddress>? AppUsers { get; set; }
    }
}
