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
                    hr = home.Resultado(rnd, hd, ha) / 2;
                    rr = rival.Resultado(rnd, hd, ha) / 2;
                }
                else
                {
                    hr = home.Resultado(rnd, hd, ha);
                    rr = rival.Resultado(rnd, rd, ra);
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

    }
}
