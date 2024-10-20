using AutoFixture;
using Hahn.API.Controllers;
using HAHN.Application.Tickets.Commands;
using HAHN.Application.Tickets.Queries;
using HAHN.Domain.DTO;
using HAHN.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HAHN.Tests.Controllers
{
    public class TicketsControllerTests
    {
        private readonly Fixture _fixture;
        private readonly TicketsController _controller;
        private readonly Mock<IMediator> _mediatorMock = new Mock<IMediator>();
        public TicketsControllerTests()
        {
            _fixture = new Fixture();
            _controller = new TicketsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetPaginatedTickets_ShouldReturnOk_WhenPaginatedTicketsExist()
        {
            // Arrange
            var expectedTickets = new PaginatedTickets
            {
                TotalCount = 10,
                Tickets =
                [
                    new() { TicketId = 1, Description = "Ticket 1", Status = TicketStatus.Open, Date = DateTime.UtcNow },
                    new() { TicketId = 2, Description = "Ticket 2", Status = TicketStatus.Closed, Date = DateTime.UtcNow.AddDays(-1) }
                ]
            };

            _mediatorMock
                .Setup(mediator => mediator.Send(It.IsAny<GetPaginatedTickets.Query>(), default))
                .ReturnsAsync(expectedTickets);

            // Act
            var result = await _controller.GetPaginatedTickets(1, 5);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var actualTickets = Assert.IsAssignableFrom<PaginatedTickets>(actionResult.Value);

            Assert.Equal(expectedTickets.TotalCount, actualTickets.TotalCount);
            Assert.Equal(expectedTickets.Tickets.Count, actualTickets.Tickets.Count);
        }

        [Fact]
        public async Task CreateTicket_ShouldReturnOk_WhenTicketIsCreated()
        {
            // Arrange
            var ticket = new Ticket
            {
                TicketId = 1,
                Description = "New ticket description",
                Status = TicketStatus.Open,
                Date = DateTime.UtcNow
            };

            var createdTicket = new Ticket
            {
                TicketId = 1,
                Description = "New ticket description",
                Status = TicketStatus.Open,
                Date = DateTime.UtcNow
            };

            _mediatorMock
                .Setup(mediator => mediator.Send(It.IsAny<CreateTicket.Command>(), default))
                .ReturnsAsync(createdTicket);

            // Act
            var result = await _controller.CreateTicket(ticket);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var actualTicket = Assert.IsAssignableFrom<Ticket>(actionResult.Value);

            Assert.Equal(createdTicket.TicketId, actualTicket.TicketId);
            Assert.Equal(createdTicket.Description, actualTicket.Description);
            Assert.Equal(createdTicket.Status, actualTicket.Status);
            Assert.Equal(createdTicket.Date, actualTicket.Date);
        }

        [Fact]
        public async Task CreateTicket_ShouldReturnBadRequest_WhenTicketCreationFails()
        {
            // Arrange
            var ticket = new Ticket { TicketId = 1, Description = "Ticket to fail", Status = TicketStatus.Open, Date = DateTime.UtcNow };

            _mediatorMock
                .Setup(mediator => mediator.Send(It.IsAny<CreateTicket.Command>(), default))
                .ReturnsAsync((Ticket)null);

            // Act
            var result = await _controller.CreateTicket(ticket);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task UpdateTicket_ShouldReturnOk_WhenTicketIsUpdated()
        {
            // Arrange
            var ticket = new Ticket { TicketId = 1, Description = "Updated ticket", Status = TicketStatus.Open, Date = DateTime.UtcNow };

            _mediatorMock
                .Setup(mediator => mediator.Send(It.IsAny<UpdateTicket.Command>(), default))
                .ReturnsAsync(ticket);

            // Act
            var result = await _controller.UpdateTicket(ticket.TicketId, ticket);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var updatedTicket = Assert.IsAssignableFrom<Ticket>(actionResult.Value);

            Assert.Equal(ticket.TicketId, updatedTicket.TicketId);
            Assert.Equal(ticket.Description, updatedTicket.Description);
            Assert.Equal(ticket.Status, updatedTicket.Status);
            Assert.Equal(ticket.Date, updatedTicket.Date);
        }

        [Fact]
        public async Task UpdateTicket_ShouldReturnBadRequest_WhenTicketUpdateFails()
        {
            // Arrange
            var ticket = new Ticket { TicketId = 1, Description = "Ticket to fail", Status = TicketStatus.Open, Date = DateTime.UtcNow };

            _mediatorMock
                .Setup(mediator => mediator.Send(It.IsAny<UpdateTicket.Command>(), default))
                .ReturnsAsync((Ticket)null);

            // Act
            var result = await _controller.UpdateTicket(ticket.TicketId, ticket);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteTicket_ShouldReturnOk_WhenTicketIsDeleted()
        {
            // Arrange
            _mediatorMock
                .Setup(mediator => mediator.Send(It.IsAny<DeleteTicket.Command>(), default))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteTicket(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteTicket_ShouldReturnBadRequest_WhenTicketDeletionFails()
        {
            // Arrange
            _mediatorMock
                .Setup(mediator => mediator.Send(It.IsAny<DeleteTicket.Command>(), default))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteTicket(1);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
