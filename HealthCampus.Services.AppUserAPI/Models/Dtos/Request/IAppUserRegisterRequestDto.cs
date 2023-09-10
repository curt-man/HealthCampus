using HealthCampus.Services.AppUserAPI.Enums;

namespace HealthCampus.Services.AppUserAPI.Models.Dto.Request
{
    public interface IAppUserRegisterRequestDto
    {
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Password { get; set; }

        public AppUser ToAppUser(LanguagesEnum? userLanguage = null);
    }
}