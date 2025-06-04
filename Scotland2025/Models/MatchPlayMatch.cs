namespace Scotland2025.Models;

public class MatchPlayMatch
{
    public int MatchNumber { get; set; }
    public MatchPlayTeam Team1 { get; set; } = new();
    public MatchPlayTeam Team2 { get; set; } = new();
}
