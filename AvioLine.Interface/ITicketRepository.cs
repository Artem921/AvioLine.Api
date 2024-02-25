using AvioLine.Domain.DTO;

namespace AvioLine.Interface
{
	public interface ITicketRepository
	{
		Task<IEnumerable<TicketDTO>> GetAllAsync();

		Task<TicketDTO> GetByIdAsync(string id);

		Task DeleteAsync(string id);

		Task AddAsync(TicketDTO ticket);
	}
}
