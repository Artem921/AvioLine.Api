using AutoMapper;
using AvioLine.Domain.Models.WeatherViewModel;
using AvioLine.Domain.WeatherDTO;

namespace Mappers.Profiles.WeatherForecast
{
    public class WeatherForecastMapperConfig : Profile
    {
        public WeatherForecastMapperConfig() => CreateMap<WeatherForecastDTO, WeatherForecastViewModel>();

    }
}
