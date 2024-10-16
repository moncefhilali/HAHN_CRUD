using HAHN.Application.Tickets.Commands.CreateTicketQuery;
using HAHN.Application.Tickets.Queries.GetAllTicketsQuery;
using HAHN.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hahn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var response = await _mediator.Send(new GetAllTicketsQuery());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {
            var response = await _mediator.Send(new CreateTicketCommand() { Ticket = ticket });
            return Ok(response);
        }
    }
}
