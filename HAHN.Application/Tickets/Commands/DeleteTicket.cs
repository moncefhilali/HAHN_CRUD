using HAHN.Domain.Interfaces;
using MediatR;

namespace HAHN.Application.Tickets.Commands
{
    public class DeleteTicket
    {
        public class Command : IRequest<bool>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly ITicketRepository _repository;
            public Handler(ITicketRepository repository)
            {
                _repository = repository;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var response = await _repository.DeleteAsync(request.Id);
                return response;
            }
        }
    }
}
