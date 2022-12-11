namespace BasketLeague2.Utils.Models
{
    public class Team
    {
        /// <summary>
        /// Código identificador del equipo
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Nombre completo del equipo
        /// </summary>
        public string NombreCompleto { get; set; }
        /// <summary>
        /// Abreviación del nombre del equipo
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Puntuación en ataque del equipo
        /// </summary>
        public int Ataque { get; set; }
        /// <summary>
        /// Puntuación en defensa del equipo
        /// </summary>
        public int Defensa { get; set; }
        /// <summary>
        /// Puntuación en tiro del equipo
        /// </summary>
        public int Tiro { get; set; }
        /// <summary>
        /// Puntuación en rebote del equipo
        /// </summary>
        public int Rebote { get; set; }
        /// <summary>
        /// Nombre del dueño del equipo
        /// </summary>
        public string Dueño { get; set; }
        /// <summary>
        /// Nombre de la canción
        /// </summary>
        public string Song { get; set; }

        /// <summary>
        /// El equipo en cuestión ataca a un rival
        /// </summary>
        /// <param name="rival">Equipo rival</param>
        /// <param name="rnd">Random number generator</param>
        /// <returns>Puntuación máxima a la que puede aspirar el quipo</returns>
        public int Atacar(Team rival, Random rnd)
        {
            return 80 + (rnd.Next(5, 10) * Ataque + rnd.Next(5, 10) * Tiro) - (rnd.Next(1, 5) * rival.Defensa + rnd.Next(1, 5) * rival.Rebote);
        }

        /// <summary>
        /// El equipo en cuestión se defiende del rival
        /// </summary>
        /// <param name="rival">Equipo rival</param>
        /// <param name="rnd">Random number generator</param>
        /// <returns>Puntuación mínima a la que puede aspirar el quipo</returns>
        public int Defender(Team rival, Random rnd)
        {
            return 50 + (rnd.Next(5, 10) * Defensa + rnd.Next(5, 10) * Rebote) - (rnd.Next(1, 5) * rival.Ataque + rnd.Next(1, 5) * rival.Tiro);
        }

        /// <summary>
        /// Sabiendo el máximo y el mínimo posibles para el equipo, devuelve un resultado
        /// </summary>
        /// <param name="defender">Mínimo al que puede llegar el equipo debido a su defensa</param>
        /// <param name="atacar">Máximo al que puede llegar el equipo debido a su ataque</param>
        /// <returns>Puntos finales del equipo</returns>
        public int Resultado(Random rnd, int defender, int atacar)
        {
            int result;
            if (defender < atacar)
            {
                result = rnd.Next(defender, atacar);
            }
            else
            {
                result = rnd.Next(atacar, defender);
            }
            return result;
        }

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}