using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scotland2025.Application.Abstractions.DatesAndTime;
using Scotland2025.Application.DbContexts;
using Scotland2025.Infrastructure.Data.DbContexts;
using Scotland2025.Infrastructure.DatesAndTime;

namespace Scotland2025.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();

            services.AddDatabase(configuration);

            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Scotland2025Db");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null or empty.");
            }

            services.AddDbContext<Scotland2025DbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
