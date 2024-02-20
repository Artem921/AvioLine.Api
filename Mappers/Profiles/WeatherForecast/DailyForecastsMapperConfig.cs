using AutoMapper;
using AvioLine.Domain.Models.WeatherViewModel;
using AvioLine.Domain.WeatherDTO;

namespace Mappers.Profiles.WeatherForecast
{
    public class DailyForecastsMapperConfig : Profile
    {
        public DailyForecastsMapperConfig() => CreateMap<DailyForecasts, DailyForecastsViewModel>();

    }
}
