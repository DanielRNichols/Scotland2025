using Microsoft.Extensions.DependencyInjection;
using Scotland2025.Application.Abstractions.JsonOptions;
using Scotland2025.Application.Abstractions.Versioning;
using Scotland2025.Application.Versioning;
using System.Reflection;

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
        services.AddScoped<IVersioningService, VersioningService>();

        return services;
    }

}
