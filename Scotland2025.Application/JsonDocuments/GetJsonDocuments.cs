using ErrorOr;
using Scotland2025.Application.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using Scotland2025.Application.DbContexts;

namespace Scotland2025.Application.JsonDocuments;
public record GetJsonDocumentsQuery() : IQuery<ErrorOr<IList<JsonDocument>>>;

public class GetJsonDocumentsQueryHandler : IQueryHandler<GetJsonDocumentsQuery, ErrorOr<IList<JsonDocument>>>
{
    private readonly Scotland2025DbContext _dbContext;

    public GetJsonDocumentsQueryHandler(IDbContextFactory<Scotland2025DbContext> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
    }

    public async Task<ErrorOr<IList<JsonDocument>>> Handle(GetJsonDocumentsQuery request, CancellationToken cancellationToken)
    {
        var jsonDocuments = await _dbContext.JsonDocuments.AsNoTracking().ToListAsync(cancellationToken);
        return jsonDocuments;
    }
}
