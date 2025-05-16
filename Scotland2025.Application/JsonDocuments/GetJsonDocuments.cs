using ErrorOr;
using Scotland2025.Application.Abstractions.Data;
using Scotland2025.Application.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Scotland2025.Application.JsonDocuments;
public record GetJsonDocumentsQuery() : IQuery<ErrorOr<IList<JsonDocument>>>;

public class GetJsonDocumentsQueryHandler : IQueryHandler<GetJsonDocumentsQuery, ErrorOr<IList<JsonDocument>>>
{
    private readonly IScotland2025DbContext _dbContext;

    public GetJsonDocumentsQueryHandler(IScotland2025DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ErrorOr<IList<JsonDocument>>> Handle(GetJsonDocumentsQuery request, CancellationToken cancellationToken)
    {
        var jsonDocuments = await _dbContext.JsonDocuments.AsNoTracking().ToListAsync(cancellationToken);
        return jsonDocuments;
    }
}
