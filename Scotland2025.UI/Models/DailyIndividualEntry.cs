﻿namespace Scotland2025.UI.Models;
public class DailyIndividualEntry
{
    public string Name { get; set; } = string.Empty;
    public double Hcp { get; set; }
    public int Gross { get; set; }
    public double Net { get; set; }
    public int Pos { get; set; }
    public double Winnings { get; set; }
}
