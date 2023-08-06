using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCampus.Services.AuthenticationServiceAPI.Models
{
    /// <summary>
    /// Model representing an address associated with a specific user.
    /// </summary>
    [PrimaryKey("AddressId", "AppUserId")]
    public class AppUserAddress
    {

        /// <summary>
        /// Reference to the user associated with this address.
        /// </summary>
        public virtual AppUser AppUser { get; set; }


        /// <summary>
        /// Reference to the address.
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Flag indicating if this is the main address associated with the user.
        /// </summary>
        public bool IsMainAddress { get; set; }
    }
}
