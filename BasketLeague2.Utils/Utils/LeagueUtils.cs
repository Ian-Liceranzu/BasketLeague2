using BasketLeague2.Utils.Models;

namespace BasketLeague2.Utils.Utils
{
    public class LeagueUtils
    {
        public static List<Match> ListMatches(List<Team> listTeam)
        {
            var matches = new List<Match>();

            if (listTeam.Count % 2 != 0)
            {
                listTeam.Add(new Team { Codigo = 100, NombreCompleto = "PRUEBA" });
            }

            int numDays = (listTeam.Count - 1);
            int halfSize = listTeam.Count / 2;

            List<Team> teams = new();

            teams.AddRange(listTeam);
            teams.RemoveAt(0);

            int teamsSize = teams.Count;

            for (int day = 0; day < numDays; day++)
            {
                int teamIdx = day % teamsSize;

                matches.Add(new Match() { Fecha = DateTime.Now.AddDays(day + 1), Equipo1 = teams[teamIdx], Equipo2 = listTeam[0] });

                for (int idx = 1; idx < halfSize; idx++)
                {
                    int firstTeam = (day + idx) % teamsSize;
                    int secondTeam = (day + teamsSize - idx) % teamsSize;
                    matches.Add(new Match() { Fecha = DateTime.Now.AddDays(day + 1), Equipo1 = teams[firstTeam], Equipo2 = teams[secondTeam] });
                }
            }

            return matches;
        }
    }
}
