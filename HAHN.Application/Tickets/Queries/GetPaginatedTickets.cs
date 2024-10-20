using HAHN.Domain.DTO;
using HAHN.Domain.Interfaces;
using MediatR;

namespace HAHN.Application.Tickets.Queries
{
    public class GetPaginatedTickets
    {
        public class Query : IRequest<PaginatedTickets> 
        {
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
        }

        public class Handler : IRequestHandler<Query, PaginatedTickets>
        {
            private readonly ITicketRepository _repository;
            public Handler(ITicketRepository repository)
            {
                _repository = repository;
            }

            public async Task<PaginatedTickets> Handle(Query request, CancellationToken cancellationToken)
            {
                var (tickets, totalCount) = await _repository.GetPaginatedTicketsAsync(request.PageNumber, request.PageSize);

                return new PaginatedTickets
                {
                    TotalCount = totalCount,
                    Tickets = tickets.ToList()
                };
            }
        }
    }
}
