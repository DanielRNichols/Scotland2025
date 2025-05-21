using Scotland2025.Application.Roster;

namespace Scotland2025.UI.Abstractions.Data;

public interface IRosterService
{
    Task<IList<RosterEntry>> GetRosterAsync(CancellationToken cancellationToken = default);
}
