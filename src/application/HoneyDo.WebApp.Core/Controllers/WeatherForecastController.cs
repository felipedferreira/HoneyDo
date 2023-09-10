using HoneyDo.WebApp.Application.Abstractions;
using HoneyDo.WebApp.Core.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HoneyDo.WebApp.Core.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [ServiceFilter(typeof(TimingActionFilter))]
    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get(IWeatherForecastService service, CancellationToken cancellationToken = default) => Ok(service.GetWeatherForecast(cancellationToken));
}