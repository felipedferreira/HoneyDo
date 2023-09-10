using System.Collections.Generic;
using System.Threading;

namespace HoneyDo.WebApp.Application.Abstractions;


public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> GetWeatherForecast(CancellationToken cancellationToken = default);
}