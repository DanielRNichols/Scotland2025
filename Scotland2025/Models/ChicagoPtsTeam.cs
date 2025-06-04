namespace Scotland2025.Models;

public class ChicagoPtsTeam
{
    public ChicagoPtsTeamEntry Player1 { get; set; } = new();
    public ChicagoPtsTeamEntry Player2 { get; set; } = new();
    public ChicagoPtsTeamEntry Team { get; set; } = new();
}
