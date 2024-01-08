using HealthCampus.CommonUtilities.Enums;
using HealthCampus.CommonUtilities.Utilities;
using HealthCampus.CommonUtilities.Extensions;
using HealthCampus.Services.LocationAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#region Configuring AutoMapper

// Just kidding, AutoMapper is a peace of shit.
// We do mapping manually here.

#endregion

#region Configuring Database

builder.Services.AddDbContext<LocationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocationDatabase")));

#endregion

#region Configuring Identity

builder.Services.AddJwtBearerAuthentication(builder.Configuration);

builder.Services.AddAuthorizationPolicies();    

#endregion


builder.Services.AddSwaggerConfiguration();

var app = builder.Build();


SeedDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseGlobalExceptionHandler();

app.Run();



void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {

        var dbContext = scope.ServiceProvider.GetRequiredService<LocationDbContext>();
        if (dbContext.Database.GetPendingMigrations().Count() > 0)
        {
            dbContext.Database.Migrate();
        }

        var seeder = new Seeder(dbContext);

        seeder.SeedData();

    }
}