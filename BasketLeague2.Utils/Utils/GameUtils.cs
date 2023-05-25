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
                int ha = home.Atacar(rival, rnd);
                int hd = home.Defender(rival, rnd);

                int ra = rival.Atacar(home, rnd);
                int rd = rival.Defender(home, rnd);

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

                int diferencia = hr - rr;

                if (diferencia == 0)
                {
                    repeat = true;
                }
                else if (diferencia > 0)
                {
                    repeat = false;
                }
                else
                {
                    repeat = false;
                }
            } while (repeat);

            return new Result()
            {
                Equipo1 = home.NombreCompleto,
                Equipo2 = rival.NombreCompleto,
                Fecha = DateTime.Now,
                Resultado1 = hr,
                Resultado2 = rr,
            };
        }

        public static void SimulateGameWithPlayers(List<Player> homePlayers, List<Player> rivalPlayers)
        {
            // Define the weights for each stat
            int[] weights = { 2, 1, 1, 2, 2, -1 };

            // Generate random stats for each player on each team
            var rand = new Random();
            var teamAStats = GenerateStats(homePlayers, rand);
            var teamBStats = GenerateStats(rivalPlayers, rand);

            // Calculate the total score for each team
            var teamAScore = CalculateScore(teamAStats, weights);
            var teamBScore = CalculateScore(teamBStats, weights);

            // Determine the winner and print the result
            var winner = (teamAScore > teamBScore) ? "Team A" : "Team B";
            Console.WriteLine("The winner is {0} with a score of {1}-{2}", winner, teamAScore, teamBScore);
        }

        public static int[][] GenerateStats(List<Player> players, Random rand)
        {
            var stats = new int[players.Count][];
            for (var i = 0; i < players.Count; i++)
            {
                stats[i] = new int[6];
                stats[i][0] =  (int)(rand.Next(0, 30) * (players[i].PointsScored / 10.0));  // Points scored
                stats[i][1] = (int)(rand.Next(0, 15) * (players[i].Rebounds / 10.0));  // Rebounds
                stats[i][2] = (int)(rand.Next(0, 10) * (players[i].Assists / 10.0));  // Assists
                stats[i][3] = (int)(rand.Next(0, 5) * (players[i].Steals / 10.0));   // Steals
                stats[i][4] = (int)(rand.Next(0, 5) * (players[i].Blocks / 10.0));   // Blocks
                stats[i][5] = (int)(rand.Next(0, 5) * (players[i].Turnovers / 10.0));   // Turnovers
            }
            return stats;
        }

        private static int CalculateScore(int[][] stats, int[] weights)
        {
            var totalScore = 0;
            for (var i = 0; i < stats.Length; i++)
            {
                var playerScore = 0;
                for (var j = 0; j < stats[i].Length; j++)
                {
                    playerScore += stats[i][j] * weights[j];
                }
                totalScore += playerScore;
            }
            return totalScore;
        }

    }
}
