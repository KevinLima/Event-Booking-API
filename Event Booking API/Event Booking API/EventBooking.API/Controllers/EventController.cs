using Microsoft.AspNetCore.Mvc;
using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Domain.Services;
using System;

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
        public IActionResult CreateEvent([FromBody] Event eventBooking)
        {
            try
            {
                _eventService.CreateEvent(eventBooking);
                return Ok(new
                {
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
            return Ok(events);
        }
    }
}
