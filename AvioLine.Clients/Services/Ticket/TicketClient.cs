using AvioLine.Clients.Base;
using AvioLine.Domain;
using AvioLine.Domain.DTO;
using AvioLine.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AvioLine.Clients.Services.Ticket
{
    public class TicketClient :BaseClient ,ITicketService
    {
        public TicketClient() : base( ConstantAddressApi.TicketAddress)
        {
        }

        public async Task<IEnumerable<TicketDTO>> GetAllAsync() => Get<List<TicketDTO>>($"{serviceAddress}");
   
        
        public async Task<TicketDTO> GetByIdAsync(string id)=>Get<TicketDTO>($"{serviceAddress}/{id}");


        public async Task AddAsync(TicketDTO ticket) => Post($"{serviceAddress}/Add", ticket);
    
        public async Task DeleteAsync(string id)=> Delete($"{serviceAddress}/{id}");
      
    }
}
