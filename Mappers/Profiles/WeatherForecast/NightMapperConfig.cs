using AutoMapper;
using AvioLine.Domain.Models.WeatherViewModel;
using AvioLine.Domain.WeatherDTO;

namespace Mappers.Profiles.WeatherForecast
{
    public class NightMapperConfig : Profile
    {
        public NightMapperConfig() => CreateMap<Night, NightViewModel>();

    }
}
