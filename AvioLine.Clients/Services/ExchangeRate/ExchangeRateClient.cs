using AvioLine.Clients.Base;
using AvioLine.Clients.Services.Abstract;
using AvioLine.Domain;
using AvioLine.Domain.DTO.ExchangeRateDTO;
using Microsoft.Extensions.Configuration;

namespace AvioLine.Clients.Services.ExchangeRate
{
    public class ExchangeRateClient : BaseClient, IExchangeRateClient
    {
        public ExchangeRateClient() : base( ConstantAddressApi.ExchangeRateAddress)
        {
        }

        public CurrencyDTO Get()
        {
            var currency = Get<CurrencyDTO>(serviceAddress);

            return currency;
        }
    }
}
