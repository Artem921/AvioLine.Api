using AvioLine.Domain.DTO;

namespace AvioLine.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDTO>> GetAllAsync();

        Task<TicketDTO> GetByIdAsync(string id);

        Task DeleteAsync(string id);

        Task AddAsync(TicketDTO ticket);
    }
}
