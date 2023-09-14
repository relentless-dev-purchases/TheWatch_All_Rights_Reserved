
using Microsoft.AspNetCore.Mvc;
using TheWatch.Shared.Data;

namespace TheWatch.Server.Controllers
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Provides WeatherForecast services. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        /// <summary>   (Immutable) the summaries. </summary>
        private static readonly string[] Summaries = new[]
        {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        /// <summary>   (Immutable) the logger. </summary>
        private readonly ILogger<WeatherForecastController> _logger;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor of WeatherForecast services. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///
        /// <param name="logger">   The logger. </param>
        ///-------------------------------------------------------------------------------------------------

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Returns a list of WeatherForecast. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///
        /// <returns>   An enumerator that allows foreach to be used to process the matched items. </returns>
        ///-------------------------------------------------------------------------------------------------

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogDebug("Request new WeatherForecast info at {DT}", DateTime.Now.ToLongTimeString());

            return Enumerable.Range(1, 6).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}