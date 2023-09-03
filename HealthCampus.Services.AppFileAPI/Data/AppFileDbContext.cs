using Microsoft.EntityFrameworkCore;
using HealthCampus.Services.AppFileAPI.Models;
using HealthCampus.Services.AppFileAPI.Utilities;
using System.ComponentModel;

namespace HealthCampus.Services.AppFileAPI.Data
{
    public class AppFileDbContext : DbContext
    {
        public AppFileDbContext(DbContextOptions<AppFileDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppFile> AppFiles { get; set; }
        public DbSet<FileContentType> FileContentTypes { get; set; }
    }
}

