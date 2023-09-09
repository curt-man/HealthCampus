using AutoMapper;
using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Models.Dto;

namespace HealthCampus.Services.AppUserAPI.Utilities.Mapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<AppUserRegisterProfile>();
                config.AddProfile<AdminAppUserRegisterProfile>();
                config.CreateMap<AddressDto, Address>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
