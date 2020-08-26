using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Challenge.API.DependencyInjections
{
    public static class ControllersCustomizationsExtensions
    {
        public static void AddControllersCustomizations(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });
        }
    }
}
