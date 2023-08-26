using AutoMapper;
using HealthCampus.Services.AppFileAPI.Models;
using HealthCampus.Services.AppFileAPI.Models.Dto;

namespace HealthCampus.Services.AppFileAPI.Utilities
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AppFile, AppFileResponseDto>();
                config.CreateMap<AppFileResponseDto, AppFile>();
            });
            return mappingConfig;
        }
    }
}
