using System;
using System.Threading.Tasks;
using Material.Application.Resources.Materials.Common.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Material.WebApi.ExceptionHandling
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception is MinTemperatureLowerApplicationException)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 400;
                string responseJson = "The minimum temperature must always be less than or equal to the maximum temperature.";
                await context.Response.WriteAsync(responseJson);
            }
        }
    }
}
