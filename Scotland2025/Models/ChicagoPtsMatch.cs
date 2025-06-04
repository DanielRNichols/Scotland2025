namespace Scotland2025.Models;

public class ChicagoPtsMatch
{
    public int MatchNumber { get; set; }
    public ChicagoPtsTeam Team1 { get; set; } = new();
    public ChicagoPtsTeam Team2 { get; set; } = new();
}
