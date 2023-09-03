using AutoMapper;
using HealthCampus.CommonUtilities.Enums;
using HealthCampus.Services.AppUserAPI.Enums;
using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Models.Dto;

namespace HealthCampus.Services.AppUserAPI.Utilities.Mapper
{
    public class AdminAppUserProfile : Profile
    {
        public AdminAppUserProfile()
        {
            CreateMap<AppUser, AdminAppUserRegistrationRequestDto>()
                .ForMember(
                    dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(
                    dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(
                    dest => dest.EmailAddress, opt => opt.MapFrom(src => src.Email))
                .ForMember(
                    dest => dest.EmailAddress, opt => opt.MapFrom(src => src.UserName))
                .ForMember(
                    dest => dest.Address, opt => opt.MapFrom(src => src.Addresses.Where(x => x.IsMainAddress).FirstOrDefault().Address))
                .ForMember(
                    dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(
                    dest => dest.TIN, opt => opt.MapFrom(src => src.TIN))
                .ForMember(
                    dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(
                    dest => dest.Gender, opt => opt.MapFrom(src => src.GenderId))
                .ForMember(
                    dest => dest.Language, opt => opt.MapFrom(src => (LanguagesEnum)src.Languages.Max(x => x.ProficiencyId)));



            var guid = Guid.NewGuid();

            CreateMap<AdminAppUserRegistrationRequestDto, AppUser>()
                .ForMember(
                    dest => dest.Id, opt => opt.MapFrom(src => guid))
                .ForMember(
                    dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(
                    dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(
                    dest => dest.SecondName, opt => opt.MapFrom(src => src.SecondName))
                .ForMember(
                    dest => dest.Email, opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(
                    dest => dest.UserName, opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(
                    dest => dest.Addresses, opt => opt.MapFrom(src => src.Address == null ? null :
                        new List<AppUserAddress>()
                        {
                            new AppUserAddress()
                            {
                                Address = src.Address,
                                IsMainAddress = true,
                                AppUserId = guid
                            }
                        }))
                .ForMember(
                    dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(
                    dest => dest.TIN, opt => opt.MapFrom(src => src.TIN))
                .ForMember(
                    dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(
                    dest => dest.GenderId, opt => opt.MapFrom(src => src.Gender))
                .ForMember(
                    dest => dest.Languages, opt => opt.MapFrom(src => src.Language == null ? null :
                        new List<AppUserLanguage>()
                        {
                            new AppUserLanguage()
                            {
                                AppUserId = guid,
                                LanguageId = (LanguagesEnum)src.Language,
                                ProficiencyId = ProficienciesEnum.Native
                            }
                        }))
                .ForMember(
                    dest => dest.RegisteredAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
