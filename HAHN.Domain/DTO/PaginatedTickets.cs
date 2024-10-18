using HAHN.Domain.Entities;

namespace HAHN.Domain.DTO
{
    public class PaginatedTickets
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public List<Ticket>? Tickets { get; set; }
    }
}
