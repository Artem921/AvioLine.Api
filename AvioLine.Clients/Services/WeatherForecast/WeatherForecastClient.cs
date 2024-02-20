using AvioLine.Clients.Base;
using AvioLine.Clients.Services.Abstract;
using AvioLine.Domain;
using AvioLine.Domain.Models.WeatherViewModel;
using AvioLine.Domain.WeatherDTO;
using Microsoft.Extensions.Configuration;

namespace AvioLine.Clients.WeatherForecast
{
    public class WeatherForecastClient:BaseClient,IWeatherForecastClient
	{
		public WeatherForecastClient() : base(ConstantAddressApi.AccuWeather) { }

		public WeatherForecastViewModel Get()
		{

			var weatherDTO= Get<WeatherForecastDTO>(serviceAddress);

			var weather= Mappers.Mapping.Mapper.Map<WeatherForecastViewModel>(weatherDTO);

			return weather;


		}

	}
}
