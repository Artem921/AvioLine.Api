using AvioLine.Clients.Base;
using AvioLine.Domain;
using AvioLine.Domain.DTO;
using AvioLine.Domain.Entities;
using AvioLine.Domain.Models;
using AvioLine.Interfaces;
using Mappers;

namespace AvioLine.Clients.Services.Ticket
{
    public class TicketClient :BaseClient ,ITicketService<TicketViewModel>
    {
        public TicketClient() : base( ConstantAddressApi.TicketAddress)
        {
        }

        public async Task<IEnumerable<TicketViewModel>> GetAllAsync()
        {
            var ticketsDTO=Get<List<TicketDTO>>($"{serviceAddress}");

            var ticketsVM= Mapping.Mapper.Map<IEnumerable<TicketViewModel>>(ticketsDTO);

            return ticketsVM;
        }


        public async Task<TicketViewModel> GetByIdAsync(string id)
        {

           var ticketDTO= Get<TicketDTO>($"{serviceAddress}/{id}");

           var ticketVM = Mapping.Mapper.Map<TicketViewModel>(ticketDTO);

            return ticketVM;
        }


        public async Task AddAsync(TicketViewModel ticket)
        {
            var ticketDTO= Mapping.Mapper.Map<TicketDTO>(ticket);

            Post($"{serviceAddress}/Add", ticketDTO);
        }
    
        public async Task DeleteAsync(string id)=> Delete($"{serviceAddress}/{id}");
      
    }
}
