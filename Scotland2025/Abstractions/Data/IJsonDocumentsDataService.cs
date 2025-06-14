using ErrorOr;
using Scotland2025.Models;

namespace Scotland2025.Abstractions.Data;
public interface IJsonDocumentsDataService
{
    Task<T?> GetAsync<T>(string documentName, CancellationToken cancellationToken = default) where T : class;

    Task<Info> GetInfoAsync(CancellationToken cancellationToken = default);
    Task<IList<BestBallNetTeam>> GetBestBallNetTeamsAsync(string name, CancellationToken cancellationToken = default);
    Task<IList<ChicagoPtsMatch>> GetChicagoPtsAsync(string name, CancellationToken cancellationToken = default);
    Task<IList<ClosestToHoleEntry>> GetClosestToHoleAsync(string name, CancellationToken cancellationToken = default);
    Task<IList<DailyIndividualEntry>> GetDailyIndividualAsync(string name, CancellationToken cancellationToken = default);
    Task<IList<DailyScatsEntry>> GetDailyScatsAsync(string name, CancellationToken cancellationToken = default);
    Task<IList<DailyScatCalculationEntry>> GetDailyScatCalculationsAsync(string name, CancellationToken cancellationToken = default);
    Task<DailyScatStats> GetDailyScatStatsAsync(string name, CancellationToken cancellationToken = default);
    Task<IList<IndividualScores>> GetIndividualScoresAsync(string name, CancellationToken cancellationToken = default);
    Task<Leaderboard> GetLeaderboardAsync(CancellationToken cancellationToken = default);
    Task<IList<LotteryEntry>> GetLotteryAsync(CancellationToken cancellationToken = default);
    Task<IList<MatchPlayMatch>> GetMatchPlayAsync(string name, CancellationToken cancellationToken = default);
    Task<IList<MoneyTotalEntry>> GetMoneyTotalsAsync(CancellationToken cancellationToken = default);
    Task<IList<RosterEntry>> GetRosterAsync(CancellationToken cancellationToken = default);
    Task<Scorecard> GetScorecardAsync(string name, CancellationToken cancellationToken = default);




}
