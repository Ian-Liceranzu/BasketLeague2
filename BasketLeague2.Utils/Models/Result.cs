namespace BasketLeague2.Utils.Models
{
    public class Result
    {
        public DateTime Fecha { get; set; }
        public string Equipo1 { get; set; }
        public string Equipo2 { get; set; }
        public int Resultado1 { get; set; }
        public int Resultado2 { get; set; }
    }

    public class AdvancedResult : Result
    {
        public int[][] Stats1 { get; set; }
        public int[][] Stats2 { get; set; }
    }
}