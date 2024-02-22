using AvioLine.Clients.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AvioLine.Components
{
    public class CurrencyViewComponent : ViewComponent
    {
        private readonly IExchangeRateClient _client;

        public CurrencyViewComponent(IExchangeRateClient exchangeRateClient)
        {
            _client = exchangeRateClient;
        }
        public IViewComponentResult Invoke()
        {
            var currencyVM = _client.Get();

            return View("Currency", currencyVM);
        }

    }
}
