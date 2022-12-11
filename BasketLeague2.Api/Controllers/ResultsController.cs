using BasketLeague2.Utils.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasketLeague2.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultsController : ControllerBase
    {
        private readonly ILogger<ResultsController> _logger;

        public ResultsController(ILogger<ResultsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetResults")]
        public IEnumerable<Result> Get()
        {
            try
            {
                Random rng = new();

                List<Result> results = new();

                for (int i = 0; i < 5; i++)
                {
                    Result result = new()
                    {
                        Equipo1 = $"PRUEBA{i}",
                        Equipo2 = $"PRUEBA-2{i}",
                        Resultado1 = rng.Next(50,150),
                        Resultado2 = rng.Next(50,150),
                        Fecha = DateTime.Now
                    };

                    results.Add(result);
                }

                return results;
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                return null;
            }
        }
    }
}
