using HAHN.Domain.Entities;
using HAHN.Domain.Interfaces;
using MediatR;

namespace HAHN.Application.Tickets.Commands.CreateTicketQuery
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Ticket?>
    {
        private readonly ITicketRepository _repository;
        public CreateTicketCommandHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<Ticket?> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            // add validation

            var ticket = await _repository.CreateAsync(request.Ticket);

            if (ticket != null)
                return ticket;

            return null;
        }
    }
}
