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
            // Generate random stats for each player on each team
            var rand = new Random();
            var teamAStats = GenerateStats(homePlayers, rand);
            var teamBStats = GenerateStats(rivalPlayers, rand);

            // Calculate the total score for each team
            int teamAScore = CalculateScore(teamAStats);
            int teamBScore = CalculateScore(teamBStats);

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
                stats[i][0] = (int)(rand.Next(0, 20) * (players[i].InsideScoring / 100.0)); // Dobles
                stats[i][1] = MakeDivisible((int)(rand.Next(0, 15) * (players[i].OutsideScoring / 90.0)), 3); // Triples
                stats[i][2] = (int)(rand.Next(0, 5) * (players[i].Athleticism / 85.0)); // Athleticism
                stats[i][3] = (int)(rand.Next(0, 5) * (players[i].Playmaking / 85.0)); // Playmaking
                stats[i][4] = (int)(rand.Next(0, 15) * (players[i].Rebounding / 90.0)); // Rebounding
                stats[i][5] = (int)(rand.Next(0, 5) * (players[i].Defending / 85.0)); // Defending
            }

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(stats));

            return stats;
        }

        private static int CalculateScore(int[][] stats)
        {
            var totalScore = 0;
            for (var i = 0; i < stats.Length; i++)
            {
                var playerScore = 0;
                for (var j = 0; j < stats[i].Length; j++)
                {
                    playerScore += stats[i][j];
                }
                totalScore += playerScore;
            }
            return totalScore;
        }

        private static int MakeDivisible(int num, int div)
        {
            string numStr = num.ToString();
            int sum = 0;

            for (int i = 0; i < numStr.Length; i++)
            {
                sum += int.Parse(numStr[i].ToString());
            }

            if (sum % div != 0)
            {
                num += (div - (sum % div));
            }

            return num;
        }

    }
}
