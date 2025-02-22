using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MobileBank.Domain.Entities;
using MobileBank.Persistence.Context;
using System;

namespace MobileBank.Persistence.Seeding
{
    public static class MobileBankSeeding
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateAsyncScope();
            var database = scope.ServiceProvider.GetRequiredService<MobileBankContext>();
            Migrate(database);
            SeedAll(database);

        }

        private static void Migrate(MobileBankContext context)
        {
            context.Database.Migrate();
        }


        private static void SeedAll(MobileBankContext context)
        {
            var seeded = false;

            SeedProvider(context, ref seeded);
            SeedCustomers(context, ref seeded);
            SeedBills(context, ref seeded);

            if (seeded) context.SaveChanges();
        }

        private static void SeedProvider(MobileBankContext context, ref bool seeded)
        {
            var providers = new List<Provider>
            {
                new Provider
                {
                   Name = "Energo-Pro",
                   LogoLink = "https://www.energo-pro.ge/uploads/news/67a3238c0d492.jpg"
                },
                 new Provider
                {
                    Name = "Socar",
                    LogoLink = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCXqnd7AUNbhQk9glrPoMK1HpYZNTngytPrQ&s"
                },
                  new Provider
                {
                    Name = "Magti",
                    LogoLink = "https://www.magticom.ge/og_logo_new.jpg"
                },
                  new Provider
                {
                    Name = "Silknet",
                    LogoLink = "https://civil.ge/wp-content/uploads/2024/03/Silknet-780x470.jpg"
                }
            };

            foreach (var provider in providers)
            {
                if (context.Providers.Any(x => x.Name == provider.Name)) continue;

                context.Providers.Add(provider);

                seeded = true;
            }
        }

        private static void SeedCustomers(MobileBankContext context,ref bool seeded)
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    FirstName = "Mariami",
                    LastName = "Gogokhia",
                    Identifier = "11111100000",
                    Email = "mariamgogokhia@gmail.com",
                    PhoneNumber = "1234567890",
                    Age = 20,
                    Password = "testtest123"
                },
                new Customer
                {
                    FirstName = "Ana",
                    LastName = "Maisuradze",
                    Identifier = "11001101100",
                    Email = "anamaisuradze@gmail.com",
                    PhoneNumber = "1236547890",
                    Age = 24,
                    Password = "testpassword123"
                }

            };

            foreach (var customer in customers)
            {
                if (context.Customers.Any(x => x.Identifier == customer.Identifier)) continue;

                context.Customers.Add(customer);

                seeded = true;
            }
        }


        private static void SeedBills(MobileBankContext context, ref bool seeded)
        {

            var customer1 = context.Customers.FirstOrDefault(x => x.Identifier == "11111100000"); 
            var customer2 = context.Customers.FirstOrDefault(x => x.Identifier == "11001101100"); 

            var provider1 = context.Providers.FirstOrDefault(x => x.Name == "Energo-Pro");
            var provider2 = context.Providers.FirstOrDefault(x => x.Name == "Socar");
            var provider3 = context.Providers.FirstOrDefault(x => x.Name == "Magti");


            if (customer1 != null && provider1 != null)
            {
                if (!context.Bills.Any(x => x.ProviderId == provider1.Id && x.CustomerId == customer1.Id))
                {
                    context.Bills.Add(new Bill { Amount = -10.5m, CustomerId = customer1.Id, ProviderId = provider1.Id });
                    seeded = true;
                }
            }
            if (customer1 != null && provider2 != null)
            {
                if (!context.Bills.Any(x => x.ProviderId == provider2.Id && x.CustomerId == customer1.Id))
                {
                    context.Bills.Add(new Bill { Amount = -70.5m, CustomerId = customer1.Id, ProviderId = provider2.Id });
                    seeded = true;
                }
            }

            if (customer1 != null && provider3 != null)
            {
                if (!context.Bills.Any(x => x.ProviderId == provider3.Id && x.CustomerId == customer1.Id))
                {
                    context.Bills.Add(new Bill { Amount = -12.5m, CustomerId = customer1.Id, ProviderId = provider3.Id });
                    seeded = true;
                }
            }

            if (customer2 != null && provider3 != null)
            {
                if (!context.Bills.Any(x => x.ProviderId == provider3.Id && x.CustomerId == customer2.Id))
                {
                    context.Bills.Add(new Bill { Amount = -83.7m, CustomerId = customer2.Id, ProviderId = provider3.Id });
                    seeded = true;
                }
            }
            if (customer2 != null && provider2 != null)
            {
                if (!context.Bills.Any(x => x.ProviderId == provider2.Id && x.CustomerId == customer2.Id))
                {
                    context.Bills.Add(new Bill { Amount = -19.9m, CustomerId = customer2.Id, ProviderId = provider2.Id });
                    seeded = true;
                }
            }
        }

    }
}
