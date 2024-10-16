using HAHN.Domain.Entities;
using MediatR;

namespace HAHN.Application.Tickets.Queries.GetAllTicketsQuery
{
    public class GetAllTicketsQuery : IRequest<List<Ticket>> { }
}
