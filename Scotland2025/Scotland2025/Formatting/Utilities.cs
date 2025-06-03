namespace Scotland2025.Formatting;

public static class Utilities
{
    public static string DisplayPos(int pos) => pos switch
    {
        0 => "",
        999 => "WD",
        _ => pos.ToString()
    };

    public static string DisplayGross(int pos, int score)
    {
        if (pos == 0)
            return "";

        if (pos == 999 && score == 0 || score == 999)
            return "WD";

        return score.ToString();
    }

    public static string DisplayWinnings(double winnings) => 
        winnings < 0.01 ? "" : winnings.ToString("C2");

    public static string DisplayNetScore(bool posted, int pos, double netScore) => 
        pos > 0 && posted ? Utilities.DisplayNet(pos, netScore) : "";


    public static string DisplayNet(int pos, double net)
    {
        if (pos == 0)
            return "";

        if (net == 999)
            return "WD";

        return NetDisplay(net);
    }

    public static string NetDisplay(double net) => net switch
    {
        > 0.001 => $"+{net}",
        < -0.001 => $"{net}",
        _ => "E"
    };

    public static string NetClass(double net) => net switch
    {
        > 0.001 => "overpar",
        < -0.001 => "underpar",
        _ => "evenpar"
    };


}
