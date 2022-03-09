using Microsoft.AspNetCore.Mvc;


namespace Sherlock.Apps.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class PropertyController : ControllerBase
{  
    public PropertyController()
    {
    }

    [HttpGet(Name = "GetProperty")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}