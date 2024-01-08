using AutoMapper;
using Azure.Storage.Blobs;
using HealthCampus.Services.AppFileAPI.Data;
using HealthCampus.Services.AppFileAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HealthCampus.Services.AppFileAPI.Utilities;
using HealthCampus.Services.AppFileAPI.Services.IService;
using HealthCampus.CommonUtilities.Enums;
using HealthCampus.CommonUtilities.Utilities;
using HealthCampus.CommonUtilities.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


#region Configuring AutoMapper

// Just kidding, AutoMapper is a peace of shit.
// We do mapping manually here.

#endregion

#region Configuring Database

builder.Services.AddDbContext<AppFileDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppFileDatabase")));
builder.Services.AddSingleton(x =>
    new BlobServiceClient(builder.Configuration.GetConnectionString("AzureStorageAccount")));

#endregion

#region Configuring Identity

builder.Services.AddJwtBearerAuthentication(builder.Configuration);
builder.Services.AddAuthorizationPolicies();

#endregion

#region Configure Swagger

builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerConfiguration();

#endregion

#region Configure services

builder.Services.AddScoped<IAppFileManagerService, AppFileManagerService>();
builder.Services.AddSingleton<IBlobService, BlobService>();
builder.Services.AddSingleton<IMediaService, MediaService>();

#endregion


var app = builder.Build();


SeedDatabase();

// Configure the HTTP request pipeline.
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

        var dbContext = scope.ServiceProvider.GetRequiredService<AppFileDbContext>();
        if (dbContext.Database.GetPendingMigrations().Count() > 0)
        {
            dbContext.Database.Migrate();
        }

        var seeder = new Seeder(dbContext);

        seeder.SeedData();

    }
}