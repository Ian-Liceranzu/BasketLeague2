using BasketLeague2.Utils.Models;

namespace BasketLeague2.Utils.Utils
{
    public class GameUtils
    {
        public static Result SimulateGame(Team home, Team rival)
        {
            Random rnd = new();

            bool repeat;

            int hr;
            int rr;

            do
            {
                var ha = home.Atacar(rival, rnd);
                var hd = home.Defender(rival, rnd);

                var ra = rival.Atacar(home, rnd);
                var rd = rival.Defender(home, rnd);

                if (ha < hd && ra < rd)
                {
                    hr = Team.Resultado(rnd, hd, ha) / 2;
                    rr = Team.Resultado(rnd, hd, ha) / 2;
                }
                else
                {
                    hr = Team.Resultado(rnd, hd, ha);
                    rr = Team.Resultado(rnd, rd, ra);
                }

                var diferencia = hr - rr;

                repeat = diferencia switch
                {
                    0 => true,
                    > 0 => false,
                    _ => false
                };
            } while (repeat);

            return new Result
            {
                Equipo1 = home.NombreCompleto,
                Equipo2 = rival.NombreCompleto,
                Fecha = DateTime.Now,
                Resultado1 = hr,
                Resultado2 = rr,
            };
        }

        public static AdvancedResult SimulateGameWithPlayers(List<Player> homePlayers, List<Player> rivalPlayers)
        {
            // Generate random stats for each player on each team
            var rand = new Random();
            var teamAStats = GenerateStats(homePlayers, rand);
            var teamBStats = GenerateStats(rivalPlayers, rand);

            // Calculate the total score for each team
            var teamAScore = CalculateScore(teamAStats);
            var teamBScore = CalculateScore(teamBStats);

            // Determine the winner and print the result
            var winner = teamAScore > teamBScore ? "Team A" : "Team B";
            Console.WriteLine("The winner is {0} with a score of {1}-{2}", winner, teamAScore, teamBScore);

            return new AdvancedResult
            {
                Equipo1 = "Home",
                Equipo2 = "Rival",
                Fecha = DateTime.Now,
                Resultado1 = teamAScore,
                Resultado2 = teamBScore,
                Stats1 = teamAStats,
                Stats2 = teamBStats
            };
        }

        private static int[][] GenerateStats(IReadOnlyList<Player> players, Random rand)
        {
            var stats = new int[players.Count][];
            for (var i = 0; i < players.Count; i++)
            {
                stats[i] = new int[7];
                stats[i][0] = players[i].Codigo; // Player
                stats[i][1] = (int)(rand.Next(0, 20) * (players[i].InsideScoring / 100.0)); // Dobles
                stats[i][2] = MakeDivisible((int)(rand.Next(0, 15) * (players[i].OutsideScoring / 90.0)), 3); // Triples
                stats[i][3] = (int)(rand.Next(0, 5) * (players[i].Athleticism / 85.0)); // Athleticism
                stats[i][4] = (int)(rand.Next(0, 5) * (players[i].Playmaking / 85.0)); // Playmaking
                stats[i][5] = (int)(rand.Next(0, 15) * (players[i].Rebounding / 90.0)); // Rebounding
                stats[i][6] = (int)(rand.Next(0, 5) * (players[i].Defending / 85.0)); // Defending
            }

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(stats));

            return stats;
        }

        private static int CalculateScore(int[][] stats)
        {
            var totalScore = 0;
            foreach (var stat in stats)
            {
                var playerScore = 0;
                for (var j = 1; j < stat.Length; j++)
                {
                    playerScore += stat[j];
                }

                totalScore += playerScore;
            }

            return totalScore;
        }

        private static int MakeDivisible(int num, int div)
        {
            var numStr = num.ToString();
            var sum = numStr.Sum(t => int.Parse(t.ToString()));

            if (sum % div != 0)
            {
                num += div - sum % div;
            }

            return num;
        }
    }
}