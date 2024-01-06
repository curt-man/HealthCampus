using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.LocationAPI.Models.Dtos.Mapper
{
    public static class AppUserAddressMapper
    {
        public static AppUserAddress ToAppUserAddress(this AddressCreateDto dto, Guid appUserId)
        {
            return new AppUserAddress()
            {
                Address = dto.ToAddress(),
                AppUserId = appUserId,
                IsMainAddress = false
            };
        }
    }
}
