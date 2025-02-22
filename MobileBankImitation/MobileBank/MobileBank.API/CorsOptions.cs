using Microsoft.AspNetCore.Cors.Infrastructure;

namespace MobileBank.API
{
    public class CorsOptions
    {
        public bool CorsEnabled { get; set; }
        public string CorsOrigins { get; set; }


        public static string[] GetCorsOrigins(CorsOptions corsOptions)
        {
            return corsOptions.CorsOrigins.Split(',', StringSplitOptions.RemoveEmptyEntries);
        }

    }
}
