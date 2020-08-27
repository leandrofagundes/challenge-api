using Challenge.Application.Services.Countries;
using Challenge.CountryServiceProxy;
using Challenge.CountryServiceProxy.CacheDb;
using Challenge.CountryServiceProxy.RestCountrieAPI;
using Microsoft.Extensions.Caching.Memory;
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

            services.AddScoped(context => new APIClient(context.GetRequiredService<HttpClient>()));
            services.AddScoped(context => new DbCache(context.GetRequiredService<IMemoryCache>(), context.GetRequiredService<APIClient>()));
            services.AddScoped<ICountriesService, CountryService>(context => new CountryService(context.GetRequiredService<DbCache>()));
        }
    }
}
