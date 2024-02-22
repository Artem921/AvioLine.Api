using AvioLine.Clients.Services.Abstract;
using AvioLine.Domain.Models.WeatherViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AvioLine.Components
{
    public class WeatherForecastViewComponent : ViewComponent
    {
        private readonly IWeatherForecastClient _client;

        public WeatherForecastViewComponent(IWeatherForecastClient client)
        {
            _client = client;
        }

        public IViewComponentResult Invoke()
        {
            var weatherVM = _client.Get();

            return View("WeatherForecast", weatherVM);
        }
    }
}
