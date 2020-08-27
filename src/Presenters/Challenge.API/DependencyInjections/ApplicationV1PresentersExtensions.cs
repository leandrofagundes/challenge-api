using Microsoft.Extensions.DependencyInjection;

namespace Challenge.API.DependencyInjections
{
    public static class ApplicationV1PresentersExtensions
    {
        public static IServiceCollection AddV1Presenters(this IServiceCollection services)
        {
            services.AddScoped<UseCases.V1.Countries.Find.Presenter, UseCases.V1.Countries.Find.Presenter>();
            services.AddScoped<Application.UseCases.V1.Countries.Find.IOutputPort>(x => x.GetRequiredService<UseCases.V1.Countries.Find.Presenter>());

            services.AddScoped<UseCases.V1.Countries.Get.Presenter, UseCases.V1.Countries.Get.Presenter>();
            services.AddScoped<Application.UseCases.V1.Countries.Get.IOutputPort>(x => x.GetRequiredService<UseCases.V1.Countries.Get.Presenter>());

            services.AddScoped<UseCases.V1.Countries.GetByRegion.Presenter, UseCases.V1.Countries.GetByRegion.Presenter>();
            services.AddScoped<Application.UseCases.V1.Countries.GetByRegion.IOutputPort>(x => x.GetRequiredService<UseCases.V1.Countries.GetByRegion.Presenter>());
            
            services.AddScoped<UseCases.V1.Countries.GetRoute.Presenter, UseCases.V1.Countries.GetRoute.Presenter>();
            services.AddScoped<Application.UseCases.V1.Countries.GetRoute.IOutputPort>(x => x.GetRequiredService<UseCases.V1.Countries.GetRoute.Presenter>());

            return services;
        }
    }
}
