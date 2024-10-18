using HAHN.Application.Tickets.Commands;
using HAHN.Application.Tickets.Queries;
using HAHN.Domain.DTO;
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

        [HttpGet("paginated/")]
        public async Task<IActionResult> GetPaginatedTickets(int pageNumber = 1, int pageSize = 10)
        {
            var response = await _mediator.Send(new GetPaginatedTickets.Query() { PageNumber = pageNumber, PageSize = pageSize });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {
            var response = await _mediator.Send(new CreateTicket.Command() { Ticket = ticket });

            if(response is null)
                return BadRequest();

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, Ticket ticket)
        {
            var response = await _mediator.Send(new UpdateTicket.Command() { Id = id, Ticket = ticket });

            if (response is null)
                return BadRequest();

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            bool response = await _mediator.Send(new DeleteTicket.Command() { Id = id });

            if (response)
                return Ok();

            return BadRequest();
        }
    }
}
