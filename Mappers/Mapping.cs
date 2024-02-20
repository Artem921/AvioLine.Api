using AutoMapper;
using Mappers.Profiles.ExchangeRate;
using Mappers.Profiles.Ticket;
using Mappers.Profiles.WeatherForecast;

namespace Mappers
{
    public class Mapping
    {
        public static IMapper Mapper { get; set; }

        public static void CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(p =>
            {
                p.AddProfile<DailyForecastsMapperConfig>();
                p.AddProfile<DayMapperConfig>();
                p.AddProfile<MinimumMapperConfig>();
                p.AddProfile<NightMapperConfig>();
                p.AddProfile<TemperatureMapperConfig>();
                p.AddProfile<WeatherForecastMapperConfig>();
                p.AddProfile<ConversionRateMapperConfig>();
                p.AddProfile<CurrencyMapperConfig>();    
                p.AddProfile<TicketMapperConfig>();
             


            });
            mapperConfiguration.AssertConfigurationIsValid();
            Mapper = mapperConfiguration.CreateMapper();
        }
    }
}
