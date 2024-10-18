using HAHN.Domain.Entities;

namespace HAHN.Domain.Interfaces
{
    public interface ITicketRepository : IGenericRepository<Ticket> 
    {
        Task<(IEnumerable<Ticket> Tickets, int TotalCount)> GetPaginatedTicketsAsync(int pageNumber, int pageSize);
    }
}
