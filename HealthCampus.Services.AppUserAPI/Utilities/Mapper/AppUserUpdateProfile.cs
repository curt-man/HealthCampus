using AutoMapper;
using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Models.Dto.Request;

namespace HealthCampus.Services.AppUserAPI.Utilities.Mapper
{
    public class AppUserUpdateProfile : Profile
    {
        public AppUserUpdateProfile()
        {
            CreateMap<AppUserUpdateRequestDto, AppUser>()
                .ForMember(
                    dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(
                    dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(
                    dest => dest.SecondName, opt => opt.MapFrom(src => src.SecondName))
                .ForMember(
                    dest => dest.GenderId, opt => opt.MapFrom(src => src.Gender))
                .ForMember(
                    dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(
                    dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(
                    dest => dest.TIN, opt => opt.MapFrom(src => src.TIN));

            CreateMap<AppUser, AppUserUpdateRequestDto>()
                .ForMember(
                    dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(
                    dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(
                    dest => dest.SecondName, opt => opt.MapFrom(src => src.SecondName))
                .ForMember(
                    dest => dest.Gender, opt => opt.MapFrom(src => src.GenderId))
                .ForMember(
                    dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(
                    dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(
                    dest => dest.TIN, opt => opt.MapFrom(src => src.TIN));
        }

    }
}
