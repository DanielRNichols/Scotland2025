namespace Scotland2025.Models;
public class DailyIndividualEntry
{
    public string TeeSlot { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public double Hcp { get; set; }
    public int Gross { get; set; }
    public double Net { get; set; }
    public int Pos { get; set; }
    public double Winnings { get; set; }
}
