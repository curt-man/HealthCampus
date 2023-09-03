using AutoMapper;
using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Models.Dto;

namespace HealthCampus.Services.AppUserAPI.Utilities.Mapper
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, AppUserRegistrationRequestDto>()
                .ForMember(
                    dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(
                    dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(
                    dest => dest.EmailAddress, opt => opt.MapFrom(src => src.Email))
                .ForMember(
                    dest => dest.EmailAddress, opt => opt.MapFrom(src => src.UserName));

            var guid = Guid.NewGuid();

            CreateMap<AppUserRegistrationRequestDto, AppUser>()
                .ForMember(
                    dest => dest.Id, opt => opt.MapFrom(src => guid))
                .ForMember(
                    dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(
                    dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(
                    dest => dest.Email, opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(
                    dest => dest.UserName, opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(
                    dest => dest.RegisteredAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
