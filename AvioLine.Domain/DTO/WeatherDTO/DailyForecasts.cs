namespace AvioLine.Domain.WeatherDTO
{
    public class DailyForecasts
    {
        public string? Date { get; set; }

        public int EpochDate { get; set; }

        public Temperature? temperature { get; set; }

        public Day? day { get; set; }

        public Night? night { get; set; }


    }
}