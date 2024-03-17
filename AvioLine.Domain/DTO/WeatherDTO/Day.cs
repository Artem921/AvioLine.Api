namespace AvioLine.Domain.WeatherDTO
{
    public class Day
    {
        public int Icon {  get; set; }

        public string? IconPhrase { get; set; }

        public bool HasPrecipitation { get; set; }

        public string? PrecipitationType { get; set; }

        public string? PrecipitationIntensity { get; set; }

        public int RainProbability { get; set; }
    }
}