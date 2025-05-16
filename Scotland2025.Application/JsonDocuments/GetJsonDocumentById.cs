using ErrorOr;
using Scotland2025.Application.Abstractions.Data;
using Scotland2025.Application.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Scotland2025.Application.JsonDocuments;
public record GetJsonDocumentByIdQuery(int Id) : IQuery<ErrorOr<JsonDocument>>;

public class GetJsonDocumentByIdQueryHandler : IQueryHandler<GetJsonDocumentByIdQuery, ErrorOr<JsonDocument>>
{
    private readonly IScotland2025DbContext _dbContext;

    public GetJsonDocumentByIdQueryHandler(IScotland2025DbContext dbContext)
    {
        _dbContext = dbContext;
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
