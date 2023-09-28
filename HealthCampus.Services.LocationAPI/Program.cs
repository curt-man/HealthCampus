using HealthCampus.CommonUtilities.Enums;
using HealthCampus.CommonUtilities.Utilities;
using HealthCampus.Services.LocationAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Configuring AutoMapper

// Just kidding, AutoMapper is a peace of shit.
// We do mapping manually here.

#endregion

#region Configuring Database

builder.Services.AddDbContext<LocationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocationDatabase")));

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


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setup =>
{
    // Include 'SecurityScheme' to use JWT Authentication
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

});





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