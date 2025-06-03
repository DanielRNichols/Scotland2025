using ErrorOr;
using MediatR;
using Scotland2025.Application.Abstractions.JsonOptions;
using Scotland2025.Application.Abstractions.Queries;
using Scotland2025.Application.JsonDocuments;
using System.Text.Json;

namespace Scotland2025.Application.Roster;

public record GetRosterQuery() : IQuery<ErrorOr<IList<RosterEntry>>>;

public class GetRosterQueryHandler : IQueryHandler<GetRosterQuery, ErrorOr<IList<RosterEntry>>>
{
    private readonly ISender _sender;
    private readonly IJsonDocumentOptions _jsonDocumentOptions;

    public GetRosterQueryHandler(ISender sender, IJsonDocumentOptions jsonDocumentOptions)
    {
        _sender = sender;
        _jsonDocumentOptions = jsonDocumentOptions;
    }
    public async Task<ErrorOr<IList<RosterEntry>>> Handle(GetRosterQuery query, CancellationToken cancellationToken = default)
    {
        var documentName = "2025-Scotland-roster";
        var getJsonDocumentByIdQuery = new GetJsonDocumentByNameQuery(documentName);
        var result = await _sender.Send(getJsonDocumentByIdQuery, cancellationToken);
        if (result.IsError)
        {
            return result.Errors;
        }

        var jsonDocument = result.Value;
        var roster = JsonSerializer.Deserialize<List<RosterEntry>>(jsonDocument.JsonValue, _jsonDocumentOptions.JsonSerializerOptions);

        return roster ?? new List<RosterEntry>();
    }
}
