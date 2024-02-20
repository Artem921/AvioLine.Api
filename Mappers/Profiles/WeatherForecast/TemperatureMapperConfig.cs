using AutoMapper;
using AvioLine.Domain.Models.WeatherViewModel;
using AvioLine.Domain.WeatherDTO;

namespace Mappers.Profiles.WeatherForecast
{
    public class TemperatureMapperConfig : Profile
    {
        public TemperatureMapperConfig() => CreateMap<Temperature, TemperatureViewModel>();

    }
}
