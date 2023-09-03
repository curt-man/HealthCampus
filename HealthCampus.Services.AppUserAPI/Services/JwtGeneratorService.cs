using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Services.IServices;
using HealthCampus.Services.AppUserAPI.Utilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HealthCampus.Services.AppUserAPI.Services
{
    public class JwtGeneratorService : IJwtGeneratorService
    {
        private readonly JwtConfig _jwtConfig;

        public JwtGeneratorService(IOptions<JwtConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
        }

        public string GenerateToken(AppUser user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.SecretKey);
            var listOfClaims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Iss, _jwtConfig.Issuer),
                new Claim(JwtRegisteredClaimNames.Aud, _jwtConfig.Audience),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            };
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(listOfClaims),
                Expires = DateTime.UtcNow.Add(_jwtConfig.ExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = jwtHandler.CreateToken(tokenDescriptor);
            var jwt = jwtHandler.WriteToken(securityToken);
            return jwt;
        }
    }
}
