using MobileBank.API.Infrastructure.Middlewares;

namespace MobileBank.API.Infrastructure.Extensions
{
    public static class GlobalExceptionHandlerExtension
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            return builder;
        }
    }
}
