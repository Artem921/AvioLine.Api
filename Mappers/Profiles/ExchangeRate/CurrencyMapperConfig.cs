using AutoMapper;
using AvioLine.Domain.DTO.ExchangeRateDTO;
using AvioLine.Domain.Models.ExchangeRateViewModel;

namespace Mappers.Profiles.ExchangeRate
{
    public class CurrencyMapperConfig : Profile
    {
        public CurrencyMapperConfig() => CreateMap<CurrencyDTO, CurrencyViewModel>();


    }
}
