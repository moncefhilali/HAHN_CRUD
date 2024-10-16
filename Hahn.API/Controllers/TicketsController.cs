using HAHN.Application.Tickets.Commands;
using HAHN.Application.Tickets.Queries;
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
            var response = await _mediator.Send(new GetTickets.Query());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {
            var response = await _mediator.Send(new CreateTicket.Command() { Ticket = ticket });
            return Ok(response);
        }
    }
}
