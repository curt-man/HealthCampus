using HealthCampus.Services.AppUserAPI.Enums;

namespace HealthCampus.Services.AppUserAPI.Models.Dtos.Mappers
{
    public static class AppUserMapper
    {
        public static void ToAppUser(this AppUserUpdateRequestDto dto, AppUser? oldModel = null)
        {
            var model = oldModel ?? new AppUser();
            model.Id = dto.Id;
            model.FirstName = dto.FirstName;
            model.LastName = dto.LastName;
            model.SecondName = dto.SecondName;
            model.PhoneNumber = dto.PhoneNumber;
            model.TIN = dto.TIN;
            model.GenderId = dto.Gender;
            model.BirthDate = dto.BirthDate;
            model.ModifiedAt = DateTime.UtcNow;
        }

        public static AppUser ToAppUser(this AdminAppUserRegisterRequestDto dto)
        {
            var appUserId = Guid.NewGuid();
            return new AppUser()
            {
                Id = appUserId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.EmailAddress,
                UserName = dto.EmailAddress,
                PhoneNumber = dto.PhoneNumber,
                TIN = dto.TIN,
                GenderId = dto.Gender,
                BirthDate = dto.BirthDate,
                RegisteredAt = DateTime.UtcNow
            };
        }

        public static AppUser ToAppUser(this AppUserRegisterRequestDto dto)
        {
            var appUserId = Guid.NewGuid();
            return new AppUser()
            {
                Id = appUserId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.EmailAddress,
                UserName = dto.EmailAddress,
                RegisteredAt = DateTime.UtcNow,
            };
        }

        public static AppUserResponseDto ToAppUserResponse(this AppUser model)
        {
            return new AppUserResponseDto()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                GenderId = model.GenderId,
                ProfilePictureId = model.ProfilePictureId
            };
        }

    }
}
