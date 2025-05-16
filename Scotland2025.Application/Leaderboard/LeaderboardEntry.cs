namespace Scotland2025.Application.Leaderboard;
public class LeaderboardEntry
{
    public string Name { get; set; } = string.Empty;
    public double Hcp { get; set; }
    public double Kingsbarn { get; set; }
    public double Dumbarnie { get; set; }
    public double Castle { get; set; }
    public double OldCourse { get; set; }
    public double Carnoustie { get; set; } 
    public int Pos { get; set; }
    public double Total { get; set; }
    public double Winnings { get; set; }
    public DateTime UpdatedAt { get; set; }
}
