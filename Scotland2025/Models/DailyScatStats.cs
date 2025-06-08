namespace Scotland2025.Models;

public class ScatHoleStats
{
    public int HoleNumber { get; set; }
    public double LowScore { get; set; }
    public int LowCount { get; set; }
    public int LowIndex { get; set; }
    public string Winner { get; set; } = string.Empty;



}
public class DailyScatStats
{
    public int ScatType { get; set; }
    public int ScatsWon { get; set; }
    public double ScatPayout { get; set; }
    public IList<ScatHoleStats> Holes { get; set; } = new List<ScatHoleStats>();

}
