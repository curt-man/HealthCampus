using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCampus.Services.AppUserAPI.Models
{
    /// <summary>
    /// Model representing an address associated with a specific user.
    /// </summary>
    [PrimaryKey(nameof(AppUserId), nameof(AddressId))]
    public class AppUserAddress
    {
        /// <summary>
        /// The unique identifier of the user associated with this address.
        /// </summary>
        [Column(Order = 1)]
        public Guid AppUserId { get; set; }

        /// <summary>
        /// Reference to the user associated with this address.
        /// </summary>
        public AppUser? AppUser { get; set; }

        /// <summary>
        /// The unique identifier of the address.
        /// </summary>
        [Column(Order = 2)]
        public Guid AddressId { get; set; }

        /// <summary>
        /// Flag indicating if this is the main address associated with the user.
        /// </summary>
        public bool IsMainAddress { get; set; }
    }
}
