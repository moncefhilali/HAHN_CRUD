using HAHN.Domain.Entities;
using HAHN.Domain.Interfaces;
using HAHN.Infrastructure.Data;

namespace HAHN.Infrastructure.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        private readonly HahnDbContext _context;
        public TicketRepository(HahnDbContext context) : base(context) => _context = context;


    }
}
