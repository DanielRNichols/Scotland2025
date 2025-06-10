namespace Scotland2025.Models;

public class BestBallNetTeam
{
    public string TeamName { get; set; } = string.Empty;    
    public BestBallNetTeamEntry Player1 { get; set; } = new();
    public BestBallNetTeamEntry Player2 { get; set; } = new();
    public BestBallNetTeamEntry Team { get; set; } = new();

}
