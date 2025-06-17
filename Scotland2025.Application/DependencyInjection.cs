using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scotland2025.Application.Abstractions.DatesAndTime;
using Scotland2025.Application.Abstractions.JsonOptions;
using Scotland2025.Application.DbContexts;
using Scotland2025.Infrastructure.DatesAndTime;
using System.Reflection;

namespace Scotland2025.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));



        services.AddDatabase(configuration);


        //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IJsonDocumentOptions, JsonDocuments.JsonDocumentOptions>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Scotland2025Db");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null or empty.");
        }

        services.AddDbContextFactory<Scotland2025DbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }


}
