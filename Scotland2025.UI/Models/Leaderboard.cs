﻿namespace Scotland2025.UI.Models;
public class Leaderboard
{
    public int RoundsCompleted { get; set; }
    public IList<LeaderboardEntry> Entries { get; set; } = new List<LeaderboardEntry>();
}
