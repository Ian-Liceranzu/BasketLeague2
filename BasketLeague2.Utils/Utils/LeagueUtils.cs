using BasketLeague2.Utils.Models;
using Newtonsoft.Json;

namespace BasketLeague2.Utils.Utils;

public static class LeagueUtils
{
    /// <summary>
    /// Calcula el orden para el draft de la siguiente temporada en base a resultados
    /// </summary>
    public static void GetTeamOrder()
    {
        var result = new Dictionary<int, int>();

        var random = new Random();

        for (var i = 0; i < 1000; i++) // Cantidad de tiradas que se realizan
        {
            var selected = GetTeamIndex(random);

            if (selected == -1) continue;

            if (!result.TryAdd(selected, 1))
            {
                result[selected] += 1;
            }
        }

        Console.WriteLine(JsonConvert.SerializeObject(
            result.OrderByDescending(r => r.Value).ToDictionary(x => x.Key, x => x.Value), Formatting.Indented));
    }

    /// <summary>
    /// Genera un orden para una temporada
    /// </summary>
    /// <param name="teams">Equipos que van a participar en la temporada</param>
    /// <returns></returns>
    public static void GenerateSchedule(List<Team> teams)
    {
        var schedule = new List<Match>();
        var scheduleStartDate = DateTime.Now;

        var restTeams = teams.Skip(1).ToList();
        if (teams.Count % 2 != 0)
        {
            restTeams.Add(null);
        }

        var totalRounds = restTeams.Count;
        for (var day = 0; day < totalRounds; day++)
        {
            var homeTeam = teams[0];
            var awayTeam = restTeams[day % totalRounds];

            if (awayTeam != null)
            {
                schedule.Add(new Match
                {
                    Fecha = scheduleStartDate,
                    Equipo1 = homeTeam.Codigo.ToString(),
                    Equipo2 = awayTeam.Codigo.ToString()
                });
            }

            for (var index = 1; index < totalRounds / 2 + 1; index++)
            {
                var team1 = restTeams[(day + index) % totalRounds];
                var team2 = restTeams[(day + totalRounds - index) % totalRounds];

                if (team1 != null && team2 != null)
                {
                    schedule.Add(new Match
                    {
                        Fecha = scheduleStartDate,
                        Equipo1 = team1.Codigo.ToString(),
                        Equipo2 = team2.Codigo.ToString()
                    });
                }
            }

            scheduleStartDate = scheduleStartDate.AddDays(7);
        }

        Console.WriteLine(JsonConvert.SerializeObject(schedule));
    }

    /// <summary>
    /// Genera un orden para el draft
    /// </summary>
    /// <param name="random">Factor random para sumar aleatoriedad</param>
    /// <returns></returns>
    private static int GetTeamIndex(Random random)
    {
        int[] choiceWeight =
            { 3, 4, 4, 4, 5, 5, 5, 6, 6, 8 }; // Modificar en base a resultados de temporada regular
        var cumulativeSum = new int[choiceWeight.Length];
        var sum = 0;
        for (var i = 0; i < choiceWeight.Length; i++)
        {
            sum += choiceWeight[i];
            cumulativeSum[i] = sum;
        }

        var rnd = random.Next(sum);
        var teamIndex = Array.BinarySearch(cumulativeSum, rnd);
        if (teamIndex < 0)
        {
            teamIndex = ~teamIndex;
        }

        return teamIndex;
    }
}