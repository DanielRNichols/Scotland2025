using ErrorOr;
using Scotland2025.Application.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using Scotland2025.Application.DbContexts;

namespace Scotland2025.Application.JsonDocuments;
public record GetJsonDocumentByIdQuery(int Id) : IQuery<ErrorOr<JsonDocument>>;

public class GetJsonDocumentByIdQueryHandler : IQueryHandler<GetJsonDocumentByIdQuery, ErrorOr<JsonDocument>>
{
    private readonly Scotland2025DbContext _dbContext;

    public GetJsonDocumentByIdQueryHandler(IDbContextFactory<Scotland2025DbContext> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
    }

    public async Task<ErrorOr<JsonDocument>> Handle(GetJsonDocumentByIdQuery query, CancellationToken cancellationToken)
    {
        var jsonDocument = await _dbContext.JsonDocuments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);

        if (jsonDocument is null)
        {
            //throw new NotFoundException($"JsonDocument with id {query.Id} not found");
            return ApplicationErrors.JsonDocuments.NotFound(query.Id);
        }

        return jsonDocument;
    }
}
