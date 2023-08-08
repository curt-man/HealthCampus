using HealthCampus.Services.AuthenticationServiceAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AuthenticationServiceAPI.Data
{
    public class AuthenticationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        //public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<AppUserAddress> AppUsersAddresses { get; set; }
        public DbSet<AppUserLanguage> AppUsersLanguages { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Proficiency> Proficiencies { get; set; }
        public DbSet<AppUserStatus> AppUserStatuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
               new Language { Id = 1, Name = "English" },
               new Language { Id = 2, Name = "Polish" },
               new Language { Id = 3, Name = "German" },
               new Language { Id = 4, Name = "French" },
               new Language { Id = 5, Name = "Spanish" },
               new Language { Id = 6, Name = "Italian" },
               new Language { Id = 7, Name = "Russian" },
               new Language { Id = 8, Name = "Chinese" },
               new Language { Id = 9, Name = "Japanese" },
               new Language { Id = 10, Name = "Korean" },
               new Language { Id = 11, Name = "Arabic" },
               new Language { Id = 12, Name = "Hindi" },
               new Language { Id = 13, Name = "Portuguese" },
               new Language { Id = 14, Name = "Turkish" },
               new Language { Id = 15, Name = "Dutch" },
               new Language { Id = 16, Name = "Swedish" },
               new Language { Id = 17, Name = "Norwegian" },
               new Language { Id = 18, Name = "Danish" },
               new Language { Id = 19, Name = "Finnish" },
               new Language { Id = 20, Name = "Greek" },
               new Language { Id = 21, Name = "Czech" },
               new Language { Id = 22, Name = "Hungarian" },
               new Language { Id = 23, Name = "Romanian" },
               new Language { Id = 24, Name = "Bulgarian" },
               new Language { Id = 25, Name = "Croatian" },
               new Language { Id = 26, Name = "Slovak" },
               new Language { Id = 27, Name = "Ukrainian" },
               new Language { Id = 28, Name = "Hebrew" },
               new Language { Id = 29, Name = "Indonesian" },
               new Language { Id = 30, Name = "Malay" },
               new Language { Id = 31, Name = "Thai" }
            );

            modelBuilder.Entity<Proficiency>().HasData(
                new Proficiency { Id = 1, Name = "Native" },
                new Proficiency { Id = 2, Name = "Fluent" },
                new Proficiency { Id = 3, Name = "Advanced" },
                new Proficiency { Id = 4, Name = "Intermediate" },
                new Proficiency { Id = 5, Name = "Beginner" }
            );

            modelBuilder.Entity<AppUserStatus>().HasData(
                new AppUserStatus { Id = 1, Name = "Active" },
                new AppUserStatus { Id = 2, Name = "Inactive" },
                new AppUserStatus { Id = 3, Name = "Pending" },
                new AppUserStatus { Id = 4, Name = "Suspended" }
            );

            base.OnModelCreating(modelBuilder);

        }

    }
}
