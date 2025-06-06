using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private static List<WeatherData> _weatherData = new List<WeatherData>();

    [HttpGet]
    public ActionResult<IEnumerable<WeatherData>> Get()
    {
        return Ok(_weatherData);
    }

    [HttpPost]
    public ActionResult<WeatherData> Post([FromBody] WeatherData weatherData)
    {
        _weatherData.Add(weatherData);
        return Ok(weatherData);
    }
}

public class WeatherData
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}