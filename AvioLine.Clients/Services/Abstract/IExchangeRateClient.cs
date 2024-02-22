using AvioLine.Domain.Models.ExchangeRateViewModel;

namespace AvioLine.Clients.Services.Abstract
{
    public interface IExchangeRateClient
    {
        CurrencyViewModel Get();

    }
}
