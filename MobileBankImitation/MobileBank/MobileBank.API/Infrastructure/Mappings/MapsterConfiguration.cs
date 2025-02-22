﻿using Mapster;
using MobileBank.Application.Customers;
using MobileBank.Application.Providers;
using MobileBank.Domain.Entities;

namespace MobileBank.API.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<Customer, CustomerResponseModel>.NewConfig().TwoWays();

            TypeAdapterConfig<CustomerRequestModel,Customer>.NewConfig().TwoWays();

            TypeAdapterConfig<Provider, ProviderResponseModel>.NewConfig().TwoWays();

            TypeAdapterConfig<ProviderRequestModel, Provider>.NewConfig().TwoWays();

        }
    }
}
