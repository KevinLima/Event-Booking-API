using System;
using System.Collections.Generic;
using Lima.EventBooking.API.Controllers;
using Lima.EventBooking.API.Services;
using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Lima.EventBooking.Domain.ValueObjects;
using Lima.EventBooking.Infrastructure.Repositories.Interfaces;

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
            var attendee = new Attendee { Id = Guid.NewGuid(), Name = "John Doe", Ticket = new TicketType("VIP") };
            var eventBooking = new Event { Id = eventId, Attendees = new List<Attendee>() };
            _mockEventRepository.Setup(repo => repo.GetById(eventId)).Returns(eventBooking);
            _mockEventRepository.Setup(repo => repo.Save(eventBooking)).Verifiable();

            // Act
            var result = _eventController.BookEvent(eventId, attendee);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void GetEvent_ShouldReturnNotFound_WhenEventDoesNotExist()
        {
            // Arrange
            var eventId = Guid.NewGuid();
            _mockEventRepository.Setup(repo => repo.GetById(eventId)).Returns((Event)null);

            // Act
            var result = _eventController.GetEvent(eventId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void CreateEvent_ShouldReturnOk_WhenEventCreatedSuccessfully()
        {
            // Arrange
            var eventDto = new EventDTO
            {
                Name = "Test Event",
                Date = DateTime.Now.AddDays(10),
                Venue = new VenueDTO { Name = "Test Venue", Location = "Test Location" },
                Attendees = new List<AttendeeDTO>
                {
                    new AttendeeDTO { Id = Guid.NewGuid(), Name = "John Doe", TicketType = "VIP" },
                    new AttendeeDTO { Id = Guid.NewGuid(), Name = "Jane Smith", TicketType = "Regular" }
                }
            };
            _mockEventRepository.Setup(repo => repo.Save(It.IsAny<Event>())).Verifiable();

            // Act
            var result = _eventController.CreateEvent(eventDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetAllEvents_ShouldReturnOk_WithListOfEvents()
        {
            // Arrange
            var events = new List<Event>
            {
                new Event { Id = Guid.NewGuid(), Name = "Event 1", Date = new EventDate(DateTime.Now.AddDays(10)), Venue = new Venue { Name = "Venue 1", Location = "Location 1" }, Attendees = new List<Attendee>() },
                new Event { Id = Guid.NewGuid(), Name = "Event 2", Date = new EventDate(DateTime.Now.AddDays(20)), Venue = new Venue { Name = "Venue 2", Location = "Location 2" }, Attendees = new List<Attendee>() }
             };
            _mockEventRepository.Setup(repo => repo.GetAll()).Returns(events);

            // Act
            var result = _eventController.GetAllEvents();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var eventDTOs = Assert.IsType<List<EventDTO>>(okResult.Value);
            Assert.Equal(2, eventDTOs.Count);
        }
    }
}
