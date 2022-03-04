using Microsoft.AspNetCore.Mvc;
using sherlock.apps.repository.contract;
using sherlock.apps.repository.implementation;
using sherlock.apps.model;
namespace sherlock.apps.api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {        
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        IRepository iRepository = new GremlinHelper("cosmosac.gremlin.cosmos.azure.com","4iXqkbNsqqJ71PmA6UoMYBRKJtOF26VffylttQ96baTRF5aXfSDmfuyfEiX4GnMcqWafEBMvJafe6Oe8z9h6uA==","sampledb","samplegraph");
        var person = new Person{id="Andy",name="Andy",age=38};
        iRepository.AddNode(person);
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
