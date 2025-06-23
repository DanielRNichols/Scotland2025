namespace Scotland2025.Models;
public class LeaderboardEntry
{
    public string Name { get; set; } = string.Empty;
    public double Hcp { get; set; }
    public double Round1Hcp { get; set; }
    public double Round1Gross { get; set; }
    public double Round1Net { get; set; }
    public double Round2Hcp { get; set; }
    public double Round2Gross { get; set; }
    public double Round2Net { get; set; }
    public double Round3Hcp { get; set; }
    public double Round3Gross { get; set; }
    public double Round3Net { get; set; }
    public double Round4Hcp { get; set; }
    public double Round4Gross { get; set; }
    public double Round4Net { get; set; }
    public double Round5Hcp { get; set; }
    public double Round5Gross { get; set; }
    public double Round5Net { get; set; } 
    public int Pos { get; set; }
    public double Total { get; set; }
    public double Winnings { get; set; }
    public DateTime UpdatedAt { get; set; }
}
