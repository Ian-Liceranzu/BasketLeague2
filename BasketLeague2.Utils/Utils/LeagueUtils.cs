using Newtonsoft.Json;

namespace BasketLeague2.Utils.Utils
{
    public class LeagueUtils
    {
        /// <summary>
        /// Calcula el orden para el draft de la siguiente temporada en base a resultados
        /// </summary>
        private static void GetTeamOrder()
        {
            var result = new Dictionary<int, int>();

            var random = new Random();

            for (var i = 0; i < 1000; i++) // Cantidad de tiradas que se realizan
            {
                var selected = GetTeamIndex(random);
                if (selected != -1)
                {
                    if (result.ContainsKey(selected))
                    {
                        result[selected] += 1;
                    }
                    else
                    {
                        result.Add(selected, 1);
                    }
                }
            }

            Console.WriteLine(JsonConvert.SerializeObject(
                result.OrderByDescending(r => r.Value).ToDictionary(x => x.Key, x => x.Value), Formatting.Indented));
        }

        /// <summary>
        /// Genera un orden para el draft
        /// </summary>
        /// <param name="random">Factor random para sumar aleatoriedad</param>
        /// <returns></returns>
        private static int GetTeamIndex(Random random)
        {
            int[] choiceWeight = { 2, 3, 4, 4, 5, 5, 5, 6, 7, 8 }; // Modificar en base a resultados de temporada regular
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
}