using AvioLine.Clients.Base;
using AvioLine.Clients.Services.Abstract;
using AvioLine.Domain;
using AvioLine.Domain.DTO.ExchangeRateDTO;
using AvioLine.Domain.Models.ExchangeRateViewModel;

namespace AvioLine.Clients.Services.ExchangeRate
{
	public class ExchangeRateClient : BaseClient, IExchangeRateClient
    {
        public ExchangeRateClient() : base( ConstantAddressApi.ExchangeRateAddress)
        {
        }

        public CurrencyViewModel Get()
        {
            var currencyDTO = Get<CurrencyDTO>(serviceAddress);

            var currencyVM = Mappers.Mapping.Mapper.Map<CurrencyViewModel>(currencyDTO);
            return currencyVM;
        }
    }
}
