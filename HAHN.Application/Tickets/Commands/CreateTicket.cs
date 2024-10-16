using HAHN.Domain.Entities;
using HAHN.Domain.Interfaces;
using MediatR;

namespace HAHN.Application.Tickets.Commands
{
    public class CreateTicket
    {
        public class Command : IRequest<Ticket>
        {
            public Ticket Ticket { get; set; }
        }

        public class Handler : IRequestHandler<Command, Ticket?>
        {
            private readonly ITicketRepository _repository;
            public Handler(ITicketRepository repository)
            {
                _repository = repository;
            }

            public async Task<Ticket?> Handle(Command request, CancellationToken cancellationToken)
            {
                // add validation

                var ticket = await _repository.CreateAsync(request.Ticket);

                if (ticket != null)
                    return ticket;

                return null;
            }
        }
    }
}
