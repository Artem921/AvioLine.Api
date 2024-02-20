using AutoMapper;
using AvioLine.Domain.Models.WeatherViewModel;
using AvioLine.Domain.WeatherDTO;

namespace Mappers.Profiles.WeatherForecast
{
    public class MinimumMapperConfig : Profile
    {
        public MinimumMapperConfig() => CreateMap<Minimum, MinimumViewModel>();

    }
}
