using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Scotland2025.Endpoints;

public interface IApiEndpoint
{
    void MapApiEndpoint(IEndpointRouteBuilder routes);
}

public static class ApiEndpoints
{
    public static IServiceCollection AddApiEndpoints(this IServiceCollection services)
    {
        return services.AddApiEndpoints(Assembly.GetExecutingAssembly());
    }

    public static IServiceCollection AddApiEndpoints(this IServiceCollection services, Assembly assembly)
    {
        var serviceDescriptors = assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                    type.IsAssignableTo(typeof(IApiEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IApiEndpoint), type))
            .ToArray();

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }

    public static IApplicationBuilder MapApiEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
    {
        var endpoints = app.Services.GetServices<IApiEndpoint>();
        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;
        foreach (var endpoint in endpoints)
        {
            endpoint.MapApiEndpoint(builder);
        }

        return app;
    }
}
