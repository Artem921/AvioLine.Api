using AvioLine.Domain.DTO.ExchangeRateDTO;

namespace AvioLine.Clients.Services.Abstract
{
    public interface IExchangeRateClient
    {
        CurrencyDTO Get();

    }
}
