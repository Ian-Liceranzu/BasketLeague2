namespace BasketLeague2.Utils.Models
{
    public class Result
    {
        public DateTime Fecha { get; set; }
        public string Equipo1 { get; set; }
        public string Equipo2 { get; set; }
        public int Resultado1 { get; set; }
        public int Resultado2 { get; set; }
    }

    public class AdvancedResult : Result
    {
        public int[][] Stats1 { get; set; }
        public int[][] Stats2 { get; set; }
    }

    public class PlayerResult
    {
        public int Codigo { get; set; }
        public int Dobles { get; set; }
        public int Triples { get; set; }
        public int Athleticism { get; set; }
        public int Playmaking { get; set; }
        public int Rebounding { get; set; }
        public int Defending { get; set; }
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
}