namespace BasketLeague2.Utils.Models
{
    public class Match
    {
        /// <summary>
        /// Fecha del partido
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Equipo que juega en casa
        /// </summary>
        public string Equipo1 { get; set; }

        /// <summary>
        /// Equipo visitante
        /// </summary>
        public string Equipo2 { get; set; }
    }
}