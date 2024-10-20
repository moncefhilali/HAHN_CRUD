using HAHN.Domain.Entities;

namespace HAHN.Domain.DTO
{
    public class PaginatedTickets
    {
        public int TotalCount { get; set; }
        public List<Ticket>? Tickets { get; set; }
    }
}
