using HAHN.Application.Tickets.Queries.GetAllTicketQuery;
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
    }
}
