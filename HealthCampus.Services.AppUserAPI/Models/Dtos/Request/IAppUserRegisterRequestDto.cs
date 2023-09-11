using HealthCampus.Services.AppUserAPI.Enums;

namespace HealthCampus.Services.AppUserAPI.Models.Dto.Request
{
    public interface IAppUserRegisterRequestDto
    {
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Password { get; set; }

        public static abstract AppUser ToAppUser<T>(T dto, LanguagesEnum? userLanguage = null) where T : IAppUserRegisterRequestDto;
    }
}