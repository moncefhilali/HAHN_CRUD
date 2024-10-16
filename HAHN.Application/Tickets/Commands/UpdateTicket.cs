using HAHN.Domain.Entities;
using HAHN.Domain.Interfaces;
using MediatR;

namespace HAHN.Application.Tickets.Commands
{
    public class UpdateTicket
    {
        public class Command : IRequest<Ticket?>
        {
            public int Id { get; set; }
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
                var ticket = await _repository.UpdateAsync(request.Id, request.Ticket);
                // add validation
                return ticket;
            }
        }
    }
}
