using Scotland2025.Application.JsonDocuments;
using Microsoft.EntityFrameworkCore;

namespace Scotland2025.Application.Abstractions.Data;
public interface IScotland2025DbContext
{
    DbSet<JsonDocument> JsonDocuments { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
