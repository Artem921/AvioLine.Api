using AutoMapper;
using AvioLine.Domain.DTO.ExchangeRateDTO;
using AvioLine.Domain.Models.ExchangeRateViewModel;

namespace Mappers.Profiles.ExchangeRate
{
    public class ConversionRateMapperConfig : Profile
    {
        public ConversionRateMapperConfig() => CreateMap<ConversionRateDTO, ConversionRateViewModel>();

    }
}
