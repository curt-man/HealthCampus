using HealthCampus.CommonUtilities.Dto;
using HealthCampus.CommonUtilities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NotImplementedException = HealthCampus.CommonUtilities.Exceptions.NotImplementedException;

namespace HealthCampus.CommonUtilities.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode;

            statusCode = ex switch
            {
                UnauthorizedException => HttpStatusCode.Unauthorized,
                NotFoundException => HttpStatusCode.NotFound,
                BadRequestException => HttpStatusCode.BadRequest,
                IdentityException => HttpStatusCode.Unauthorized,
                NotImplementedException => HttpStatusCode.NotImplemented,
                AlreadyExistException => HttpStatusCode.Conflict,
                _ => HttpStatusCode.InternalServerError
            };

            var result = JsonSerializer.Serialize(new { ex.Message, ex.StackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(result);
        }
    }
}
