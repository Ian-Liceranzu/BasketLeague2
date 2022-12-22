using BasketLeague2.Utils.Models;

namespace BasketLeague2.Utils.Utils
{
    public class LeagueUtils
    {
        public static void ListMatches(List<Team> teams)
        {
            if (teams.Count % 2 != 0)
            {
                teams.Add(new Team() { NombreCompleto = "EQUIPO VACIO"});
            }

            int days = teams.Count - 1;
            int half = teams.Count / 2;

            List<Team> t = new();

            t.AddRange(teams);
            t.RemoveAt(0);

            int tSize = t.Count;

            for (int day = 0; day < days; day++)
            {
                Console.WriteLine("Day {0}", day + 1);

                int teamIdx = day % tSize;

                Console.WriteLine("{0} vs {1}", t[teamIdx], teams[0]);

                for (int idx = 1; idx < half; idx++)
                {
                    int first = (day + idx) % tSize;
                    int second = (day + tSize - idx) % tSize; ;
                    Console.WriteLine("{0} vs {1}", t[first], teams[second]);
                }
            }
        }
    }
}
