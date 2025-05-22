using Scotland2025.Application.Leaderboard;
using Scotland2025.Application.Lottery;
using Scotland2025.Application.MoneyTotals;
using Scotland2025.Application.Roster;

namespace Scotland2025.UI.Abstractions.Data;

public interface IDataService
{
    Task<Leaderboard?> GetLeaderboardAsync(CancellationToken cancellationToken = default);
    Task<IList<LotteryEntry>> GetLotteryAsync(CancellationToken cancellationToken = default);
    Task<IList<MoneyTotalEntry>> GetMoneyTotalsAsync(CancellationToken cancellationToken = default);
    Task<IList<RosterEntry>> GetRosterAsync(CancellationToken cancellationToken = default);

}
