using AutoMapper;
using AvioLine.Domain.Models.WeatherViewModel;
using AvioLine.Domain.WeatherDTO;

namespace Mappers.Profiles.WeatherForecast
{
    public class DayMapperConfig : Profile
    {
        public DayMapperConfig() => CreateMap<Day, DayViewModel>();

    }
}
