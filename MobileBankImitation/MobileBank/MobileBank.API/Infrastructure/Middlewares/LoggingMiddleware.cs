using System.Text;

namespace MobileBank.API.Infrastructure.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");

            var body = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                string responseBodyText = await new StreamReader(context.Response.Body, Encoding.UTF8).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                _logger.LogInformation($"Response: {context.Response.StatusCode} - {responseBodyText}");

                await responseBody.CopyToAsync(body);
            }
        }
    }
}
