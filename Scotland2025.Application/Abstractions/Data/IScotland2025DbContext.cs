using Scotland2025.Application.JsonDocuments;
using Microsoft.EntityFrameworkCore;
using Scotland2025.Application.Images;

namespace Scotland2025.Application.Abstractions.Data;
public interface IScotland2025DbContext
{
    DbSet<JsonDocument> JsonDocuments { get; }
    DbSet<Image> Images { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
