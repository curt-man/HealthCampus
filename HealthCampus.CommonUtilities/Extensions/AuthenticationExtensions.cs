using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using HealthCampus.CommonUtilities.Utilities;
using HealthCampus.CommonUtilities.Enums;

namespace HealthCampus.CommonUtilities.Extensions
{
    public static class AuthenticationExtensions
    {
        public static void AddJwtBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jwt =>
                {
                    var key = Encoding.ASCII.GetBytes(configuration.GetSection("JwtConfig:SecretKey").Value!);
                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = configuration.GetSection("JwtConfig:Issuer").Value!,
                        ValidateAudience = true,
                        ValidAudience = configuration.GetSection("JwtConfig:Audience").Value!,
                        ValidateLifetime = true,
                        RequireExpirationTime = true
                    };
                });
        }

        public static void AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
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
        }


    }
}
