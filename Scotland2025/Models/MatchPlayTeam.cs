namespace Scotland2025.Models;

public class MatchPlayTeam
{
    public MatchPlayTeamEntry Player1 { get; set; } = new();
    public MatchPlayTeamEntry Player2 { get; set; } = new();
    public MatchPlayTeamEntry Team { get; set; } = new();
    public MatchPlayTeamEntry Points { get; set; } = new();

}
