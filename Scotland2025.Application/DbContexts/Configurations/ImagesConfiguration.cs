using Scotland2025.Application.JsonDocuments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scotland2025.Application.Images;

namespace Scotland2025.Infrastructure.Data.Configurations
{
    public class ImagesConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Url).IsUnique().HasDatabaseName("IX_Images_Url");
        }
    }
}
