using System;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.Services;
using TaxCalculator.ViewModels;
using TaxCalculator.Views;

namespace TaxCalculator
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider;

        public static void Init()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            //serviceCollection.AddHttpClient();
            serviceCollection.AddHttpClient("TaxJar", client =>
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer 5da2f821eee4035db4771edab942a4cc");
            });

            serviceCollection.AddScoped<ITaxCalculator, TaxJarCalculator>();
            serviceCollection.AddScoped<ITaxService, TaxService>();
           
            

            serviceCollection.AddTransient<CalculateTaxPageViewModel>();
            serviceCollection.AddTransient<TaxLookupPageViewModel>();
        }

    }
}
