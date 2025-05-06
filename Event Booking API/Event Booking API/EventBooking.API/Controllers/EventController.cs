using Microsoft.AspNetCore.Mvc;
using Lima.EventBooking.Domain.Entities;
using System;
using Lima.EventBooking.API.DTOs;
using Lima.EventBooking.Domain.ValueObjects;
using Lima.EventBooking.API.Services;

namespace Lima.EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController: ControllerBase
    {
        private readonly EventService _eventService;

        /// <summary>
        /// Injectable service for this controllers.
        /// </summary>
        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// Add an attendee to an event. 
        /// </summary>
        /// <param name="eventId">The event to have a new attendee.</param>
        /// <param name="attendee">The attendee to be added to the event.</param>
        /// <returns>A <see cref="ObjectResult"/> and a message.</returns>
        [HttpPost("{eventId}/attendees")]
        public IActionResult BookEvent(Guid eventId, [FromBody] Attendee attendee)
        {
            try
            {
                _eventService.BookEvent(eventId, attendee);
                return Ok(new { message = "Attendee added successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get an event.
        /// </summary>
        /// <param name="eventId">The GUID id of the event.</param>
        /// <returns>A <see cref="ObjectResult"/> and the event if it was found.</returns>
        [HttpGet("{eventId}")]
        public IActionResult GetEvent(Guid eventId)
        {
            var eventBooking = _eventService.GetEventById(eventId);
            if (eventBooking == null)
            {
                return NotFound(new { message = "Event not found."});
            }
            return Ok(eventBooking);
        }

        /// <summary>
        /// Creates a event.
        /// </summary>
        /// <param name="eventDto">The event to be created.</param>
        /// <returns>A <see cref="ObjectResult"/> and the event if it was created.</returns>
        [HttpPost]
        public IActionResult CreateEvent([FromBody] EventDTO eventDto)
        {
            try
            {
                var eventBooking = new Event
                {
                    Id = Guid.NewGuid(),
                    Name = eventDto.Name,
                    Date = new EventDate(eventDto.Date),
                    Venue = new Venue
                    {
                        Id = Guid.NewGuid(),
                        Name = eventDto.Venue.Name,
                        Location = eventDto.Venue.Location,
                    },
                    Attendees = eventDto.Attendees.Select(
                        a => new Attendee
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Ticket = new TicketType(
                                a.TicketType)
                        }).ToList()
                };

                _eventService.CreateEvent(eventBooking);
                return Ok(new { 
                    message = "Event created successfully", 
                    eventId = eventBooking.Id
                });
            }
            catch (Exception ex) {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get all events.
        /// </summary>
        /// <returns>A <see cref="ObjectResult"/> and a list of events.</returns>
        [HttpGet]
        public IActionResult GetAllEvents()
        {
            var events = _eventService.GetAllEvents();

            var eventDTOs = events.Select(e => new EventDTO
            {
                Id = e.Id,
                Name = e.Name,
                Date = e.Date.Date,
                Venue = new VenueDTO
                {
                    Name = e.Venue.Name,
                    Location = e.Venue.Location,
                },
                Attendees = e.Attendees.Select(a => new AttendeeDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    TicketType = a.Ticket.Type
                }).ToList()
            }).ToList();

            return Ok(eventDTOs);
        }
    }
}