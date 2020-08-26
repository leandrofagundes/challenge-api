using Challenge.WebUI.Models;
using Challenge.WebUI.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Challenge.WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ChallengeAPI:baseUrl"]) });
            builder.Services.AddScoped(context => new WebHttpClient(context.GetRequiredService<HttpClient>()));
            builder.Services.AddScoped<ICountryModel, CountryModel>(context => new CountryModel(context.GetRequiredService<WebHttpClient>()));

            await builder.Build().RunAsync();
        }
    }
}
