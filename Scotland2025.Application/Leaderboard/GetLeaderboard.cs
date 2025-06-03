using ErrorOr;
using MediatR;
using Scotland2025.Application.Abstractions.JsonOptions;
using Scotland2025.Application.Abstractions.Queries;
using Scotland2025.Application.JsonDocuments;
using System.Text.Json;

namespace Scotland2025.Application.Leaderboard;
public record GetLeaderboardQuery() : IQuery<ErrorOr<Leaderboard>>;

public class GetLeaderboardQueryHandler : IQueryHandler<GetLeaderboardQuery, ErrorOr<Leaderboard>>
{
    private readonly ISender _sender;
    private readonly IJsonDocumentOptions _jsonDocumentOptions;

    public GetLeaderboardQueryHandler(ISender sender, IJsonDocumentOptions jsonDocumentOptions)
    {
        _sender = sender;
        _jsonDocumentOptions = jsonDocumentOptions;
    }
    public async Task<ErrorOr<Leaderboard>> Handle(GetLeaderboardQuery query, CancellationToken cancellationToken = default)
    {
        var documentName = "2025-Scotland-leaderboard";
        var getJsonDocumentByIdQuery = new GetJsonDocumentByNameQuery(documentName);
        var result = await _sender.Send(getJsonDocumentByIdQuery, cancellationToken);
        if (result.IsError)
        {
            return result.Errors;
        }

        var jsonDocument = result.Value;
        var leaderboard = JsonSerializer.Deserialize<Leaderboard>(jsonDocument.JsonValue, _jsonDocumentOptions.JsonSerializerOptions);

        return leaderboard ?? new Leaderboard();
    }
}
