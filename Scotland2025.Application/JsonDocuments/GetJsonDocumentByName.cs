using ErrorOr;
using Scotland2025.Application.Abstractions.Data;
using Scotland2025.Application.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Scotland2025.Application.JsonDocuments;
public record GetJsonDocumentByNameQuery(string DocumentName) : IQuery<ErrorOr<JsonDocument>>;

public class GetJsonDocumentByNameQueryHandler : IQueryHandler<GetJsonDocumentByNameQuery, ErrorOr<JsonDocument>>
{
    private readonly IScotland2025DbContext _dbContext;

    public GetJsonDocumentByNameQueryHandler(IScotland2025DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ErrorOr<JsonDocument>> Handle(GetJsonDocumentByNameQuery query, CancellationToken cancellationToken)
    {
        var jsonDocument = await _dbContext.JsonDocuments.AsNoTracking()
            .FirstOrDefaultAsync(x => x.DocumentName == query.DocumentName.ToLower(), cancellationToken);

        if (jsonDocument is null)
        {
            //throw new NotFoundException($"JsonDocument with id {query.Id} not found");
            return ApplicationErrors.JsonDocuments.NotFound(query.DocumentName);
        }

        return jsonDocument;
    }
}
