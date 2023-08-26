namespace HealthCampus.Services.AuthenticationServiceAPI.Utilities
{
    public class JwtConfig
    {
        /// <summary>
        /// The secret key used to sign the JWT token.
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// The issuer of the JWT token.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// The audience of the JWT token.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// The expiration time of the JWT token.
        /// </summary>
        public TimeSpan ExpirationTime { get; set; }
    }
}
