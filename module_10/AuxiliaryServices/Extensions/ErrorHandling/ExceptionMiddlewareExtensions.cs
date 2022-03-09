using Microsoft.AspNetCore.Builder;

namespace AuxiliaryServices.Extensions.ErrorHandling
{
    public static class ExceptionMiddlewareExtensions
    { //IApplicationBuilder
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}