using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger _logger;

        public WeatherForecastController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(WeatherForecastController));
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            Exception ex = new("This is a test exception");
            ex.Data.Add("DemoKey", "DemoValue");
            _logger.LogError(ex, "An error occurred while fetching weather data");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
