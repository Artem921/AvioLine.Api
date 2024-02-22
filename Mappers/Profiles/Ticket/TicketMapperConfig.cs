using AutoMapper;
using AvioLine.Domain.DTO;
using AvioLine.Domain.Entities;
using AvioLine.Domain.Models;

namespace Mappers.Profiles.Ticket
{
    public class TicketMapperConfig : Profile
    {
        public TicketMapperConfig()
        {
            CreateMap<TicketEntity, TicketDTO>().ReverseMap();

            CreateMap<TicketDTO, TicketViewModel>().ReverseMap();

          


        }
    }
}
