using Scotland2025.UI.Abstractions.Data;
using Scotland2025.UI.Models;

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

    public async Task<IList<BestBallNetTeam>> GetBestBallNetTeamsAsync(string name, CancellationToken cancellationToken = default)
    {
        var result = await _jsonDocumentService.GetJsonDocumentByNameAsync<IList<BestBallNetTeam>>($"2025-scotland-{name}bestballnetteams", cancellationToken);
        return result ?? new List<BestBallNetTeam>();
    }

    public async Task<IList<ClosestToHoleEntry>> GetClosestToHoleAsync(string name, CancellationToken cancellationToken = default)
    {
        var result = await _jsonDocumentService.GetJsonDocumentByNameAsync<IList<ClosestToHoleEntry>>($"2025-scotland-{name}closesttohole", cancellationToken);
        return result ?? new List<ClosestToHoleEntry>();
    }

    public async Task<IList<DailyIndividualEntry>> GetDailyIndividualAsync(string name, CancellationToken cancellationToken = default)
    {
        var result = await _jsonDocumentService.GetJsonDocumentByNameAsync<IList<DailyIndividualEntry>>($"2025-scotland-{name}individual", cancellationToken);
        return result ?? new List<DailyIndividualEntry>();
    }

    public async Task<IList<DailyScatsEntry>> GetDailyScatsAsync(string name, CancellationToken cancellationToken = default)
    {
        var result = await _jsonDocumentService.GetJsonDocumentByNameAsync<IList<DailyScatsEntry>>($"2025-scotland-{name}scats", cancellationToken);
        return result ?? new List<DailyScatsEntry>();
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

    public async Task<IList<MatchPlayMatch>> GetMatchPlayAsync(string name, CancellationToken cancellationToken = default)
    {
        var result = await _jsonDocumentService.GetJsonDocumentByNameAsync<IList<MatchPlayMatch>>($"2025-scotland-{name}matchplay", cancellationToken);
        return result ?? new List<MatchPlayMatch>();
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
