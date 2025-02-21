using Mapster;
using MobileBank.Application.Customers;
using MobileBank.Domain.Entities;

namespace MobileBank.API.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<Customer, CustomerResponseModel>.NewConfig().TwoWays();

            TypeAdapterConfig<CustomerRequestModel,Customer>.NewConfig().TwoWays();
        }
    }
}
