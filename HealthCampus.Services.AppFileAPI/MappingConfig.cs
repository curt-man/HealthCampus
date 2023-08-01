using AutoMapper;
using HealthCampus.Services.AppFileAPI.Models;
using HealthCampus.Services.AppFileAPI.Models.Dto;

namespace HealthCampus.Services.AppFileAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AppFile, AppFileRequestDto>();
                config.CreateMap<AppFileRequestDto, AppFile>();
                config.CreateMap<AppFile, AppFileResponseDto>();
                config.CreateMap<AppFileResponseDto, AppFile>();
            });
            return mappingConfig;
        }
    }
}
