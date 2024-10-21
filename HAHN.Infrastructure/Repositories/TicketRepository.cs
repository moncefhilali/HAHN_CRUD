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

        public async Task<(IEnumerable<Ticket> Tickets, int TotalCount)> GetPaginatedTicketsAsync(int pageNumber, int pageSize, string sorting, string filter)
        {
            IList<Ticket> tickets = [];
            if (sorting == "desc")
                tickets = await _context.Tickets
                    .OrderByDescending(t => t.TicketId)
                    .Where(t => t.Description.Contains(filter))
                    .ToListAsync();
            else
                tickets = await _context.Tickets
                    .OrderBy(t => t.TicketId)
                    .Where(t => t.Description.Contains(filter))
                    .ToListAsync();

            var totalTickets = tickets.Count();
            tickets = tickets
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return (tickets, totalTickets);
        }
    }
}
