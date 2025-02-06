using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController] // Type attribute
[Route("[controller]")] // where to redirect the http requests to this controller -- [controller] is a token that will be replaced by the name of the controller(localhost:5000/WeatherForecast)
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" // Things that can be returned from our controller
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger) // service availible to the controller 
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")] // Endpoint for the controller: specifies the method that will be used by the controller 
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
