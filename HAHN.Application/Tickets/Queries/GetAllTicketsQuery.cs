using HAHN.Domain.Entities;
using MediatR;

namespace HAHN.Application.Tickets.Queries
{
    public class GetAllTicketsQuery : IRequest<List<Ticket>> { }
}
