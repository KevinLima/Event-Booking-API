using Microsoft.AspNetCore.Mvc;
using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Domain.Services;
using System;
using Lima.EventBooking.API.DTOs;
using Lima.EventBooking.Domain.ValueObjects;

namespace Lima.EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController: ControllerBase
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

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
