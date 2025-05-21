using Scotland2025.Application.Roster;
using Scotland2025.UI.Abstractions.Data;
using System.Net.Http.Json;
using System.Text.Json;

namespace Scotland2025.UI.Data.Roster;

public class RosterService : IRosterService
{
    private readonly ILogger<RosterService> _logger;
    private readonly IJsonDocumentService<IList<RosterEntry>> _jsonDocumentService;

    public RosterService(ILogger<RosterService> logger, IJsonDocumentService<IList<RosterEntry>> jsonDocumentService)
    {
        _logger = logger;
        _jsonDocumentService = jsonDocumentService;
    }

    public async Task<IList<RosterEntry>> GetRosterAsync(CancellationToken cancellationToken = default)
    {
        var documentName = "2025-scotland-roster";
        var result = await _jsonDocumentService.GetJsonDocumentByNameAsync(documentName, cancellationToken);
        return result ?? new List<RosterEntry>();
    }
}
