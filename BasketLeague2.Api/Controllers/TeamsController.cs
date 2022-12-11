using BasketLeague2.Utils.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasketLeague2.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ILogger<TeamsController> _logger;

        public TeamsController(ILogger<TeamsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTeams")]
        public IEnumerable<Team> Get()
        {
            try
            {
                Random rng = new();

                List<Team> teams = new();

                for(int i = 0; i< 5; i++)
                {
                    Team team = new()
                    {
                        Nombre = $"PRUEBA{i}",
                        Ataque = rng.Next(1, 9),
                        Defensa = rng.Next(1, 9),
                        Tiro = rng.Next(1, 9),
                        Rebote = rng.Next(1, 9),
                        NombreCompleto = $"PRUEBA{i}",
                        Codigo = rng.Next(1, 9),
                        Dueño = $"PRUEBA{i}",
                        Song = $"PRUEBA{i}"
                    };

                    teams.Add(team);
                }

                return teams;
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                return null;
            }
        }
    }
}