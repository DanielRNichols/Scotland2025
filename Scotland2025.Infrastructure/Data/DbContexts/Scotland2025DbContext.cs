using Scotland2025.Application.Abstractions.Data;
using Scotland2025.Application.JsonDocuments;
using Microsoft.EntityFrameworkCore;
using Scotland2025.Application.Images;

namespace Scotland2025.Infrastructure.Data.DbContexts
{
    public class Scotland2025DbContext : DbContext, IScotland2025DbContext
    {
        public Scotland2025DbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<JsonDocument> JsonDocuments => Set<JsonDocument>();
        public DbSet<Image> Images => Set<Image>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Scotland2025DbContext).Assembly);
        }
    }
}
