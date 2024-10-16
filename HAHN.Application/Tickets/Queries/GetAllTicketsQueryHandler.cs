using HAHN.Domain.Entities;
using HAHN.Domain.Interfaces;
using MediatR;

namespace HAHN.Application.Tickets.Queries
{
    public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, List<Ticket?>>
    {
        private readonly ITicketRepository _repository;
        public GetAllTicketsQueryHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Ticket?>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
        {
            var tickets =  await _repository.GetAllAsync();

            // apply filtering


            // apply sorting

            return tickets.ToList();
        }
    }
}
