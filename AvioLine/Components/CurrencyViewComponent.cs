using AvioLine.Clients.Services.Abstract;
using AvioLine.Domain.Models.ExchangeRateViewModel;
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
            var currencyDTO = _client.Get();

            var currencyVM = Mappers.Mapping.Mapper.Map<CurrencyViewModel>(currencyDTO);

            return View("Currency", currencyVM);
        }

    }
}
