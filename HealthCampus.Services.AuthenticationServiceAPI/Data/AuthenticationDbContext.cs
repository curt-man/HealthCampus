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
        public DbSet<Gender> Genders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            base.OnModelCreating(modelBuilder);

        }

    }
}
