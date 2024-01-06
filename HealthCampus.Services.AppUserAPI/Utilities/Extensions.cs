using HealthCampus.Services.AppUserAPI.Data;
using HealthCampus.Services.AppUserAPI.Enums;
using HealthCampus.Services.AppUserAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace HealthCampus.Services.AppUserAPI.Utilities
{
    public static class Extensions
    {
        public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
             {
                 options.Password.RequireDigit = false;
                 options.Password.RequiredLength = 6;
                 options.Password.RequireLowercase = false;
                 options.Password.RequireUppercase = false;
                 options.Password.RequireNonAlphanumeric = false;
                 options.SignIn.RequireConfirmedEmail = false;
                 options.SignIn.RequireConfirmedPhoneNumber = false;
                 options.User.RequireUniqueEmail = true;
             })
            .AddEntityFrameworkStores<AppUserDbContext>()
            .AddDefaultTokenProviders();

            services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));
        }
    }
}
