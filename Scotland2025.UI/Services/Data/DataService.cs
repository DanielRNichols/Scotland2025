using Scotland2025.Application.Leaderboard;
using Scotland2025.Application.Lottery;
using Scotland2025.Application.MoneyTotals;
using Scotland2025.Application.Roster;
using Scotland2025.UI.Abstractions.Data;

namespace Scotland2025.UI.Services.Data;

public class DataService : IDataService
{
    private readonly ILogger<DataService> _logger;
    private readonly IJsonDocumentService _jsonDocumentService;

    public DataService(ILogger<DataService> logger, IJsonDocumentService jsonDocumentService)
    {
        _logger = logger;
        _jsonDocumentService = jsonDocumentService;
    }
    public async Task<Leaderboard?> GetLeaderboardAsync(CancellationToken cancellationToken = default)
    {
        return await _jsonDocumentService.GetJsonDocumentByNameAsync<Leaderboard>("2025-scotland-leaderboard", cancellationToken);
    }

    public async Task<IList<LotteryEntry>> GetLotteryAsync(CancellationToken cancellationToken = default)
    {
        var result = await _jsonDocumentService.GetJsonDocumentByNameAsync<IList<LotteryEntry>>("2025-scotland-lottery", cancellationToken);
        return result ?? new List<LotteryEntry>();
    }

    public async Task<IList<MoneyTotalEntry>> GetMoneyTotalsAsync(CancellationToken cancellationToken = default)
    {
        var result = await _jsonDocumentService.GetJsonDocumentByNameAsync<IList<MoneyTotalEntry>>("2025-scotland-money", cancellationToken);
        return result ?? new List<MoneyTotalEntry>();
    }

    public async Task<IList<RosterEntry>> GetRosterAsync(CancellationToken cancellationToken = default)
    {
        var documentName = "2025-scotland-roster";
        var result = await _jsonDocumentService.GetJsonDocumentByNameAsync<IList<RosterEntry>>(documentName, cancellationToken);
        return result ?? new List<RosterEntry>();
    }
}
