﻿namespace Scotland2025.Models;
public class LotteryEntry
{
    public string Name { get; set; } = string.Empty;
    public string Pick { get; set; } = string.Empty;
    public int Pos {  get; set; }
    public double Money { get; set; }
}
