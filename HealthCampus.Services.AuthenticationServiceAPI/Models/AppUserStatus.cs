namespace HealthCampus.Services.AuthenticationServiceAPI.Models
{
    /// <summary>
    /// Model representing a user status.
    /// </summary>
    public class AppUserStatus
    {
        /// <summary>
        /// The unique identifier of the user status.
        /// </summary>
        public byte Id { get; set; }

        /// <summary>
        /// The status of the user.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The description of the user status.
        /// </summary>
        public string Description { get; set; }
    }
}