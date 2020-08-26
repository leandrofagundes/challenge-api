using Microsoft.Extensions.DependencyInjection;

namespace Challenge.API.DependencyInjections
{
    public static class ApplicationV1UseCasesExtensions
    {
        public static IServiceCollection AddV1UseCases(this IServiceCollection services)
        {
            services.AddScoped<Challenge.Application.UseCases.V1.Countries.Find.IUseCase, Challenge.Application.UseCases.V1.Countries.Find.UseCase>();
            services.AddScoped<Challenge.Application.UseCases.V1.Countries.Get.IUseCase, Challenge.Application.UseCases.V1.Countries.Get.UseCase>();

            return services;
        }

    }
}
