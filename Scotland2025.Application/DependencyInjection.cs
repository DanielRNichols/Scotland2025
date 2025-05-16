using Microsoft.Extensions.DependencyInjection;
using Scotland2025.Application.Abstractions.JsonOptions;
using System.Reflection;
using System.Text.Json;

namespace Scotland2025.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IJsonDocumentOptions, JsonDocuments.JsonDocumentOptions>();

        return services;
    }

}
