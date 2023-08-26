using AutoMapper;
using HealthCampus.Services.AuthenticationServiceAPI.Models;
using HealthCampus.Services.AuthenticationServiceAPI.Models.Dto;

namespace HealthCampus.Services.AuthenticationServiceAPI.Utilities
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AppUser, AppUserResponseDto>();
                config.CreateMap<AppUserResponseDto, AppUser>();
            });
            return mappingConfig;
        }
    }
}
