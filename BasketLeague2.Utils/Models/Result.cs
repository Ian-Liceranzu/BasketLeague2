namespace BasketLeague2.Utils.Models;

/// <summary>
/// Match result
/// </summary>
public class Result
{
    public DateTime Fecha { get; init; }
    public string Equipo1 { get; set; } = "";
    public string Equipo2 { get; set; } = "";
    public int Resultado1 { get; init; }
    public int Resultado2 { get; init; }
}

/// <summary>
/// Result with player statistics
/// </summary>
public class AdvancedResult : Result
{
    public int[][] Stats1 { get; init; } = Array.Empty<int[]>();
    public int[][] Stats2 { get; init; } = Array.Empty<int[]>();
}

/// <summary>
/// Player individual results
/// </summary>
public class PlayerResult
{
    public int Codigo { get; init; }
    public int Dobles { get; init; }
    public int Triples { get; init; }
    public int Athleticism { get; init; }
    public int Playmaking { get; init; }
    public int Rebounding { get; init; }
    public int Defending { get; init; }
    public int Total => Dobles + Triples + Athleticism + Playmaking + Rebounding + Defending;
}

public static class PlayerResultExtension
{
    /// <summary>
    /// Converts the list of stats to a PlayerResult item
    /// </summary>
    /// <param name="stats">List of stats for each player</param>
    /// <returns>The stats as a list of individual player results</returns>
    public static IEnumerable<PlayerResult> ConvertToPlayerResult(this IEnumerable<int[]> stats)
    {
        return stats.Select(t => new PlayerResult
        {
            Codigo = t[0],
            Dobles = t[1],
            Triples = t[2],
            Athleticism = t[3],
            Playmaking = t[4],
            Rebounding = t[5],
            Defending = t[6]
        });
    }
}