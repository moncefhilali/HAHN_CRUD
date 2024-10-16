using HAHN.Domain.Entities;
using MediatR;

namespace HAHN.Application.Tickets.Commands.CreateTicketQuery
{
    public class CreateTicketCommand : IRequest<Ticket>
    {
        public Ticket Ticket {  get; set; }
    }
}
