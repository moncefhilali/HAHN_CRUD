using HAHN.Domain.Entities;
using HAHN.Domain.Interfaces;
using MediatR;

namespace HAHN.Application.Tickets.Queries
{
    public class GetTickets
    {
        public class Query : IRequest<List<Ticket>> { }

        public class Handler : IRequestHandler<Query, List<Ticket?>>
        {
            private readonly ITicketRepository _repository;
            public Handler(ITicketRepository repository)
            {
                _repository = repository;
            }

            public async Task<List<Ticket?>> Handle(Query request, CancellationToken cancellationToken)
            {
                var tickets = await _repository.GetAllAsync();
                return tickets.ToList();
            }
        }
    }
}
