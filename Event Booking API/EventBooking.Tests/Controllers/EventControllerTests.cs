using System.Net.Sockets;
using System;
using System.Collections.Generic;
using Lima.EventBooking.API.Controllers;
using Lima.EventBooking.API.Services;
using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Domain.ValueObjects;
using Lima.EventBooking.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Lima.EventBooking.Infrastructure.Repositories;


namespace EventBooking.Tests.Controllers
{
    public class EventControllerTests
    {


        private readonly Mock<IEventRepository> _mockEventRepository;
        private readonly EventService _eventService;
        private readonly EventController _eventController;

        public EventControllerTests()
        {
            _mockEventRepository = new Mock<IEventRepository>();
            _eventService = new EventService(_mockEventRepository.Object);
            _eventController = new EventController(_eventService);
        }

        [Fact]
        public void BookEvent_ShouldReturnOk_WhenAttendeeAddedSuccessfully()
        {
            // Arrange
            var eventId = Guid.NewGuid();
            var attendee = new Attendee
            {
                Id = Guid.NewGuid(),
                Name = "Pieter",
                Ticket = new TicketType("VIP")
            };
            var eventBooking = new Event
            {
                Id = eventId,
                Attendees = new List<Attendee>()
            };
            _mockEventRepository.Setup(
                repo => repo.GetById(eventId)
                ).Returns(eventBooking);

            _mockEventRepository.Setup(
                repo => repo.Save(eventBooking)
                ).Verifiable();

            // Act
            var result = _eventController.BookEvent(eventId, attendee);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            _mockEventRepository.Verify();
        }


    }
}