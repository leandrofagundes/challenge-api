using FluentMediator;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.API.DependencyInjections
{
    /// <summary>
    /// Mediator which allows us to keep the clean architecture, not being injected on our application layer.
    /// Check the github if you need help: https://github.com/ivanpaulovich/FluentMediator
    /// </summary>
    public static class ApplicationV1MediatorExtensions
    {
        public static IServiceCollection AddV1Mediators(this IServiceCollection services)
        {
            var builder = new PipelineProviderBuilder();

            AddIdentitiesUsersMediator(builder);

            var pipelineProvider = builder.Build();

            services.AddTransient<GetService>(c => c.GetService);
            services.AddTransient(c => pipelineProvider);
            services.AddTransient<IMediator, Mediator>();

            return services;
        }

        private static void AddIdentitiesUsersMediator(IPipelineProviderBuilder builder)
        {
            builder.On<Application.UseCases.V1.Countries.Get.InputData>().CancellablePipelineAsync()
                .Call<Application.UseCases.V1.Countries.Get.IUseCase>((handler, request, cancellationToken) => handler.Execute(request, cancellationToken));

            builder.On<Application.UseCases.V1.Countries.Find.InputData>().PipelineAsync()
                .Call<Application.UseCases.V1.Countries.Find.IUseCase>((handler, request) => handler.Execute(request));
        }
    }
}
