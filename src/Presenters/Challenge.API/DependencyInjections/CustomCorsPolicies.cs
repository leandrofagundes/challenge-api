using Microsoft.Extensions.DependencyInjection;

namespace Challenge.API.DependencyInjections
{
    public static class CustomCorsPolicies
    {
        public static void AddCorsPolicies(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
