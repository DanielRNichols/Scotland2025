using Scotland2025.Application.JsonDocuments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Scotland2025.Infrastructure.Data.Configurations
{
    public class JsonDocumentsConfiguration : IEntityTypeConfiguration<JsonDocument>
    {
        public void Configure(EntityTypeBuilder<JsonDocument> builder)
        {
            builder.ToTable("JsonDocuments");
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.DocumentName).IsUnique().HasDatabaseName("IX_JsonDocuments_DocumentName");
        }
    }
}
