using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IO;
using System.Reflection;

namespace Challenge.API.DependencyInjections
{
    public static class SwaggerExtensions
    {

        private static string XmlCommentsFilePath
        {
            get
            {
                string basePath = PlatformServices.Default.Application.ApplicationBasePath;
                string fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigurationOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    // Um filtro para auxiliar na geração de valores quando não houver. 
                    //options.OperationFilter<SwaggerDefaultValues>(); // TODO: Identificar necessidade

                    // O FullName é necessário pois quando duas classes tiverem o mesmo nome, ele valida pelo namespace completo.
                    options.CustomSchemaIds(x => x.FullName);

                    // Gera o arquivo XML no caminho desejado contendo os summary dos controllers.
                    options.IncludeXmlComments(XmlCommentsFilePath);
                });

            return services;
        }

        /// <summary>
        /// Prepara o Swagger e o SwaggerUI (interface do Swagger).
        /// </summary>
        public static IApplicationBuilder UseVersionedSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    options.DocumentTitle = "Challenge API Documentation";
                    // Constrói uma interface visual do Swagger para cada Endpoint de Versão encontrado na aplicação
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });

            return app;
        }
    }
}
