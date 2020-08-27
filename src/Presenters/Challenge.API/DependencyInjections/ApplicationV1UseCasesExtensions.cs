using Microsoft.Extensions.DependencyInjection;

namespace Challenge.API.DependencyInjections
{
    public static class ApplicationV1UseCasesExtensions
    {
        public static IServiceCollection AddV1UseCases(this IServiceCollection services)
        {
            services.AddScoped<Application.UseCases.V1.Countries.Find.IUseCase, Application.UseCases.V1.Countries.Find.UseCase>();
            services.AddScoped<Application.UseCases.V1.Countries.Get.IUseCase, Application.UseCases.V1.Countries.Get.UseCase>();
            services.AddScoped<Application.UseCases.V1.Countries.GetByRegion.IUseCase, Application.UseCases.V1.Countries.GetByRegion.UseCase>();
            services.AddScoped<Application.UseCases.V1.Countries.GetRoute.IUseCase, Application.UseCases.V1.Countries.GetRoute.UseCase>();

            return services;
        }

    }
}
