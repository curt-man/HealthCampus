using AutoMapper;
using HealthCampus.CommonUtilities.Extensions;
using HealthCampus.Services.AppUserAPI.Data;
using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Services;
using HealthCampus.Services.AppUserAPI.Services.IServices;
using HealthCampus.Services.AppUserAPI.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// Adding Services
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#region Configuring Database

builder.Services.AddDbContext<AppUserDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppUserDatabase"));
});

#endregion

#region Configuring AutoMapper

// Just kidding, AutoMapper is a peace of shit.
// We do mapping manually here.

#endregion

#region Configuring Services

builder.Services.AddScoped<IJwtGeneratorService, JwtGeneratorService>();
builder.Services.AddScoped<IAppUserManagerService, AppUserManagerService>();

#endregion

#region Configuring Identity

builder.Services.AddJwtBearerAuthentication(builder.Configuration);

builder.Services.AddAuthorizationPolicies();

builder.Services.AddIdentityConfiguration(builder.Configuration);

#endregion

#region Configuring Swagger

builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddSwaggerConfiguration();

#endregion

var app = builder.Build();


await SeedDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseGlobalExceptionHandler();

app.Run();


async Task SeedDatabase()
{
    using(var scope = app.Services.CreateScope())
    {

        var dbContext = scope.ServiceProvider.GetRequiredService<AppUserDbContext>();
        if (dbContext.Database.GetPendingMigrations().Count() > 0)
        {
            dbContext.Database.Migrate();
        }

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        var seeder = new Seeder(dbContext, roleManager, userManager);
        
        await seeder.SeedData();
            
    }
}