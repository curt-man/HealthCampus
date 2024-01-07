using HealthCampus.CommonUtilities.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCampus.CommonUtilities.Extensions
{
    public static class GlobalExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder appBuilder)
        {
            return appBuilder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}
