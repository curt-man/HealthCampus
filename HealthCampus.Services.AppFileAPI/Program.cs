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

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwt =>
    {
        var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:SecretKey").Value!);
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration.GetSection("JwtConfig:Issuer").Value!,
            ValidateAudience = true,
            ValidAudience = builder.Configuration.GetSection("JwtConfig:Audience").Value!,
            ValidateLifetime = true,
            RequireExpirationTime = true
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(AccessPolicy.Violet,
        policy => policy.RequireRole(
            RolesEnum.Admin.ToString()));
    options.AddPolicy(AccessPolicy.Indigo,
        policy => policy.RequireRole(
            RolesEnum.Admin.ToString(),
            RolesEnum.SysAdmin.ToString()));
    options.AddPolicy(AccessPolicy.Blue,
        policy => policy.RequireRole(
            RolesEnum.Admin.ToString(),
            RolesEnum.SysAdmin.ToString()));
    options.AddPolicy(AccessPolicy.Green,
        policy => policy.RequireRole(
            RolesEnum.Admin.ToString(),
            RolesEnum.SysAdmin.ToString(),
            RolesEnum.Employee.ToString()));
    options.AddPolicy(AccessPolicy.Yellow,
        policy => policy.RequireRole(
            RolesEnum.Admin.ToString(),
            RolesEnum.SysAdmin.ToString(),
            RolesEnum.Employee.ToString()));
    options.AddPolicy(AccessPolicy.Orange,
        policy => policy.RequireRole(
            RolesEnum.Admin.ToString(),
            RolesEnum.SysAdmin.ToString(),
            RolesEnum.Employee.ToString(),
            RolesEnum.User.ToString()));
    options.AddPolicy(AccessPolicy.Red,
        policy => policy.RequireRole(
            RolesEnum.Admin.ToString(),
            RolesEnum.SysAdmin.ToString(),
            RolesEnum.Employee.ToString(),
            RolesEnum.User.ToString(),
            RolesEnum.Guest.ToString()));
});
#endregion




builder.Services.AddSingleton<IBlobService, BlobService>();
builder.Services.AddSingleton<IMediaService, MediaService>();


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