using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.API.DependencyInjections
{
    public static class ApiVersioningExtension
    {
        public static IServiceCollection AddApiVersioningCustoms(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddVersionedApiExplorer(p =>
            {
                p.GroupNameFormat = "'v'V";
                p.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
