using HealthCampus.Services.AuthenticationServiceAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AuthenticationServiceAPI.Data
{
    public class AuthenticationDbContext : IdentityDbContext<AppUser>
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //modelBuilder.Entity<UserAddress>()
            //    .HasKey(t => new { t.UserId, t.AddressId });

            //modelBuilder.Entity<UserAddress>()
            //    .HasOne(ua => ua.User)
            //    .WithMany(u => u.UsersAddresses)
            //    .HasForeignKey(ua => ua.UserId);

            //modelBuilder.Entity<UserAddress>()
            //    .HasOne(ua => ua.Address)
            //    .WithMany(a => a.UsersAddresses)
            //    .HasForeignKey(ua => ua.AddressId);

            //modelBuilder.Entity<UserLanguage>()
            // .HasKey(t => new { t.UserId, t.LanguageId });

            //modelBuilder.Entity<UserLanguage>()
            //    .HasOne(ul => ul.User)
            //    .WithMany(u => u.UsersLanguages)
            //    .HasForeignKey(ua => ua.UserId);

            //modelBuilder.Entity<UserLanguage>()
            //    .HasOne(ul => ul.Language)
            //    .WithMany(l => l.UsersLanguages)
            //    .HasForeignKey(ua => ua.LanguageId);

            base.OnModelCreating(modelBuilder);

        }

    }
}
