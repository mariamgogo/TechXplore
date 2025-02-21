using MobileBank.Application.Accounts;
using MobileBank.Application.Bills;
using MobileBank.Application.Customers;
using MobileBank.Application.Providers;
using MobileBank.Application.Repositories;
using MobileBank.Application.Transactions;
using MobileBank.Infrastructure.Repositories;
using System.Reflection.Metadata;

namespace MobileBank.API.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICustomerRepository,CustomerRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IBillService,BillService>();
        }
    }
}
