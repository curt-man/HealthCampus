using HealthCampus.Services.LocationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.LocationAPI.Data
{
    public class LocationDbContext : DbContext
    {
        public LocationDbContext(DbContextOptions<LocationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUserAddress> AppUsersAddresses { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
