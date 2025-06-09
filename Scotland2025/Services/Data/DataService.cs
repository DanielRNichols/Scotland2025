using ErrorOr;
using MediatR;
using Scotland2025.Abstractions.Data;
using Scotland2025.Application.Abstractions.JsonOptions;
using Scotland2025.Application.JsonDocuments;
using Scotland2025.Models;
using System.Text.Json;

namespace Scotland2025.Services.Data;
public class DataService : IDataService
{
    private readonly ISender _sender;
    private readonly IJsonDocumentOptions _jsonDocumentOptions;

    public DataService(ISender sender, IJsonDocumentOptions jsonDocumentOptions)
    {
        _sender = sender;
        _jsonDocumentOptions = jsonDocumentOptions;
    }
    public async Task<T?> GetAsync<T>(string documentName, CancellationToken cancellationToken = default) where T : class
    {
        var getJsonDocumentByIdQuery = new GetJsonDocumentByNameQuery(documentName);
        var result = await _sender.Send(getJsonDocumentByIdQuery, cancellationToken);
        if (result.IsError)
        {
            return null;
        }

        var jsonDocument = result.Value;
        var data = JsonSerializer.Deserialize<T>(jsonDocument.JsonValue, _jsonDocumentOptions.JsonSerializerOptions);

        return data;
    }

    public async Task<Info> GetInfoAsync(CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<Info>("2025-scotland-info", cancellationToken);
        return result ?? new Info();
    }

    public async Task<IList<BestBallNetTeam>> GetBestBallNetTeamsAsync(string name, CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<IList<BestBallNetTeam>>($"2025-scotland-{name}bestballnet", cancellationToken);
        return result ?? new List<BestBallNetTeam>();
    }

    public async Task<IList<ChicagoPtsMatch>> GetChicagoPtsAsync(string name, CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<IList<ChicagoPtsMatch>>($"2025-scotland-{name}chicagopts", cancellationToken);
        return result ?? new List<ChicagoPtsMatch>();
    }

    public async Task<IList<ClosestToHoleEntry>> GetClosestToHoleAsync(string name, CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<IList<ClosestToHoleEntry>>($"2025-scotland-{name}closesttohole", cancellationToken);
        return result ?? new List<ClosestToHoleEntry>();
    }

    public async Task<IList<DailyIndividualEntry>> GetDailyIndividualAsync(string name, CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<IList<DailyIndividualEntry>>($"2025-scotland-{name}individual", cancellationToken);
        return result ?? new List<DailyIndividualEntry>();
    }

    public async Task<IList<DailyScatsEntry>> GetDailyScatsAsync(string name, CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<IList<DailyScatsEntry>>($"2025-scotland-{name}scats", cancellationToken);
        return result ?? new List<DailyScatsEntry>();
    }

    public async Task<DailyScatStats> GetDailyScatStatsAsync(string name, CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<DailyScatStats>($"2025-scotland-{name}scatstats", cancellationToken);
        return result ?? new DailyScatStats();
    }

    public async Task<IList<DailyScatCalculationEntry>> GetDailyScatCalculationsAsync(string name, CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<IList<DailyScatCalculationEntry>>($"2025-scotland-{name}scatcalculations", cancellationToken);
        return result ?? new List<DailyScatCalculationEntry>();
    }

    public async Task<IList<IndividualScores>> GetIndividualScoresAsync(string name, CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<IList<IndividualScores>>($"2025-scotland-{name}scores", cancellationToken);
        return result ?? new List<IndividualScores>();
    }

    public async Task<Leaderboard> GetLeaderboardAsync(CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<Leaderboard>("2025-scotland-leaderboard", cancellationToken);
        return result ?? new Leaderboard();
    }

    public async Task<IList<LotteryEntry>> GetLotteryAsync(CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<IList<LotteryEntry>>("2025-scotland-lottery", cancellationToken);
        return result ?? new List<LotteryEntry>();
    }

    public async Task<IList<MatchPlayMatch>> GetMatchPlayAsync(string name, CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<IList<MatchPlayMatch>>($"2025-scotland-{name}matchplay", cancellationToken);
        return result ?? new List<MatchPlayMatch>();
    }

    public async Task<IList<MoneyTotalEntry>> GetMoneyTotalsAsync(CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<IList<MoneyTotalEntry>>("2025-scotland-money", cancellationToken);
        return result ?? new List<MoneyTotalEntry>();
    }

    public async Task<IList<RosterEntry>> GetRosterAsync(CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<IList<RosterEntry>>("2025-scotland-roster", cancellationToken);
        return result ?? new List<RosterEntry>();
    }

    public async Task<Scorecard> GetScorecardAsync(string name, CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<Scorecard>($"2025-scotland-{name}scorecard", cancellationToken);
        return result ?? new Scorecard();
    }
}

