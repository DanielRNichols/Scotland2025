using Scotland2025.UI.Models;

namespace Scotland2025.UI.Abstractions.Data;

public interface IDataService
{
    Task<IList<BestBallNetTeam>> GetBestBallNetTeamsAsync(string name, CancellationToken cancellationToken = default);
    Task<IList<ChicagoPtsMatch>> GetChicagoPtsAsync(string name, CancellationToken cancellationToken = default);
    Task<IList<ClosestToHoleEntry>> GetClosestToHoleAsync(string name, CancellationToken cancellationToken = default);
    Task<IList<DailyIndividualEntry>> GetDailyIndividualAsync(string name, CancellationToken cancellationToken = default);
    Task<IList<DailyScatsEntry>> GetDailyScatsAsync(string name, CancellationToken cancellationToken = default);
    Task<Leaderboard?> GetLeaderboardAsync(CancellationToken cancellationToken = default);
    Task<IList<LotteryEntry>> GetLotteryAsync(CancellationToken cancellationToken = default);
    Task<IList<MatchPlayMatch>> GetMatchPlayAsync(string name, CancellationToken cancellationToken = default);
    Task<IList<MoneyTotalEntry>> GetMoneyTotalsAsync(CancellationToken cancellationToken = default);
    Task<IList<RosterEntry>> GetRosterAsync(CancellationToken cancellationToken = default);

}
