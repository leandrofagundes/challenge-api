using Microsoft.Extensions.DependencyInjection;

namespace Challenge.API.DependencyInjections
{
    public static class ApplicationV1PresentersExtensions
    {
        public static IServiceCollection AddV1Presenters(this IServiceCollection services)
        {
            services.AddScoped<Challenge.API.UseCases.V1.Countries.Find.Presenter, Challenge.API.UseCases.V1.Countries.Find.Presenter>();
            services.AddScoped<Challenge.Application.UseCases.V1.Countries.Find.IOutputPort>(x => x.GetRequiredService<UseCases.V1.Countries.Find.Presenter>());

            services.AddScoped<Challenge.API.UseCases.V1.Countries.Get.Presenter, Challenge.API.UseCases.V1.Countries.Get.Presenter>();
            services.AddScoped<Challenge.Application.UseCases.V1.Countries.Get.IOutputPort>(x => x.GetRequiredService<UseCases.V1.Countries.Get.Presenter>());

            return services;
        }
    }
}
