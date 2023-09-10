using HealthCampus.CommonUtilities.Converters;
using HealthCampus.Services.AppUserAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AppUserAPI.Data
{
    public class AppUserDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public AppUserDbContext(DbContextOptions<AppUserDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        //public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<AppUserLanguage> AppUsersLanguages { get; set; }
        public DbSet<AppUserUserStatus> AppUsersUserStatuses { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Proficiency> Proficiencies { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            builder.Properties<DateOnly?>()
                .HaveConversion<NullableDateOnlyConverter>()
                .HaveColumnType("date");
        }


    }
}
