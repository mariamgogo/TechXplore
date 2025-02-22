using MobileBank.API.Infrastructure.Localizations;
using MobileBank.Application.Bills.BillExceptions;
using MobileBank.Application.Customers.CustomerExceptions;
using MobileBank.Application.Providers.ProviderExceptions;
using System.Net;
using System.Text.Json;


namespace MobileBank.API.Infrastructure.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
      //  private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next/*, ILogger<GlobalExceptionHandlingMiddleware> logger*/)
        {
            _next = next;
           // _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
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

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = exception switch
            {
                InvalidCustomerException => new { StatusCode = (int)HttpStatusCode.BadRequest, Message = ErrorMessages.InvalidCustomer },
                CustomerNotFoundException => new { StatusCode = (int)HttpStatusCode.NotFound, Message = ErrorMessages.CustomerNotFound },
                CustomerAlreadyExistsException => new { StatusCode = (int)HttpStatusCode.Conflict, Message = ErrorMessages.CustomerAlreadyExists },
                ProviderNotFoundException => new { StatusCode = (int)HttpStatusCode.NotFound, Message = ErrorMessages.ProviderNotFound },
                ProviderAlreadyExistsException => new { StatusCode = (int)HttpStatusCode.Conflict, Message = ErrorMessages.ProviderAlreadyExists },
                BillAlreadyExistsException => new { StatusCode = (int)HttpStatusCode.Conflict, Message = ErrorMessages.BillAlreadyExists },
                BillNotFoundException => new { StatusCode = (int)HttpStatusCode.NotFound, Message = ErrorMessages.BillNotFound },
                _ => new { StatusCode = (int)HttpStatusCode.InternalServerError, Message = "something unexpected happened." }
            };

            context.Response.StatusCode = response.StatusCode;
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

    }

}
