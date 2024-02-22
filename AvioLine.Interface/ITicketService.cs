using AvioLine.Domain.DTO;

namespace AvioLine.Interfaces
{
    public interface ITicketService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(string id);

        Task DeleteAsync(string id);

        Task AddAsync(T ticket);
    }
}
