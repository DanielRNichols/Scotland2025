namespace Scotland2025.UI.Models;
public class LeaderboardEntry
{
    public string Name { get; set; } = string.Empty;
    public double Hcp { get; set; }
    public double Round1 { get; set; }
    public double Round2 { get; set; }
    public double Round3 { get; set; }
    public double Round4 { get; set; }
    public double Round5 { get; set; } 
    public int Pos { get; set; }
    public double Total { get; set; }
    public double Winnings { get; set; }
    public DateTime UpdatedAt { get; set; }
}
