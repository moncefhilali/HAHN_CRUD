using System.ComponentModel.DataAnnotations;

namespace HAHN.Domain.Entities
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public string? Description { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime Date {  get; set; }
    }

    public enum TicketStatus
    {
        Closed,
        Open
    }
}
