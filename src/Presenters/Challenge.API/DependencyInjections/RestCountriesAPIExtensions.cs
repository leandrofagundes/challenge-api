using Challenge.Application.Services.Countries;
using Challenge.CountryServiceProxy;
using Challenge.CountryServiceProxy.APIClient;
using Challenge.CountryServiceProxy.CacheDb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace Challenge.API.DependencyInjections
{
    public static class RestCountriesAPIExtensions
    {
        public static void AddRestCountriesAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            int.TryParse(configuration["RestCountriesProxy:leaseTimeInMinutes"], out int leaseTimeInMinutes);
            string baseUrl = configuration["RestCountriesAPI:baseUrl"];

            services.AddScoped(s =>
            {
                return new HttpClient
                {
                    BaseAddress = new Uri(baseUrl)
                };
            });

            services.AddSingleton(context => new InMemoryCacheDb(leaseTimeInMinutes));

            services.AddScoped<RestCountriesAPIClient, RestCountriesAPIClient>(context => new RestCountriesAPIClient(context.GetRequiredService<HttpClient>()));
            services.AddScoped<ICountriesService, CountryService>(context => new CountryService(context.GetRequiredService<InMemoryCacheDb>(), context.GetRequiredService<RestCountriesAPIClient>()));
        }
    }
}
