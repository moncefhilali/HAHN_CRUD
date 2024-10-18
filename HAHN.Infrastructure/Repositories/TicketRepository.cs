using HAHN.Domain.Entities;
using HAHN.Domain.Interfaces;
using HAHN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HAHN.Infrastructure.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        private readonly HahnDbContext _context;
        public TicketRepository(HahnDbContext context) : base(context) => _context = context;

        public async Task<(IEnumerable<Ticket> Tickets, int TotalCount)> GetPaginatedTicketsAsync(int pageNumber, int pageSize)
        {
            var totalTickets = await _context.Tickets.CountAsync();
            var tickets = await _context.Tickets
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (tickets, totalTickets);
        }
    }
}
