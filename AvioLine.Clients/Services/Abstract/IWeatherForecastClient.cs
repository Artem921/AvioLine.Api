using AvioLine.Domain.Models.WeatherViewModel;
using AvioLine.Domain.WeatherDTO;

namespace AvioLine.Clients.Services.Abstract
{
    public interface IWeatherForecastClient
	{
        WeatherForecastViewModel Get();
	}
}
