using MobileBank.API.Infrastructure.Middlewares;

namespace MobileBank.API.Infrastructure.Extensions
{
    public static class CultureExtension
    {
        public static IApplicationBuilder UseCulture(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<CultureMIddleware>();

            return builder;
        }
    }
}
