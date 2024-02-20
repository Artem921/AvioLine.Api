

namespace AvioLine.Domain.Models.WeatherViewModel
{
    public class DailyForecastsViewModel
    {
        public string Date { get; set; }

        public int EpochDate { get; set; }

        public TemperatureViewModel temperature { get; set; }

        public DayViewModel day { get; set; }

        public NightViewModel night { get; set; }


    }
}