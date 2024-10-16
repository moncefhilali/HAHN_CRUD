using HAHN.Domain.Entities;
using MediatR;

namespace HAHN.Application.Tickets.Queries.GetAllTicketQuery
{
    public class GetAllTicketsQuery : IRequest<List<Ticket>> { }
}
