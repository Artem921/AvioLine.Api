using AvioLine.Domain.DTO;
using AvioLine.Domain.Entities;
using AvioLine.Interfaces;
using Mappers;
using Microsoft.EntityFrameworkCore;

namespace AvioLine.Dal.Repositories
{
    public class TicketsRepository : ITicketService
    {
        private readonly ApplicationContext context;

        public TicketsRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<TicketDTO>> GetAllAsync()
        {
            var tickets = await context.Tickets.ToListAsync();

            return Mapping.Mapper.Map<IEnumerable<TicketDTO>>(tickets);
        }


        public async Task<TicketDTO> GetByIdAsync(string id)
        {
            var ticket = await context.Tickets.FirstOrDefaultAsync(p => p.Id == id);

            return Mapping.Mapper.Map<TicketDTO>(ticket);
        }



        public async Task AddAsync(TicketDTO ticket)
        {
            var ticket_entity = Mapping.Mapper.Map<TicketEntity>(ticket);

            await context.Tickets.AddAsync(ticket_entity);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var ticket = await context.Tickets.FirstOrDefaultAsync(p => p.Id == id);

            context.Tickets.Remove(ticket);

            await context.SaveChangesAsync();
         
        }
    }
}
