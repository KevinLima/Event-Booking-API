using Event_Booking_API.EventBooking.API.Services;
using Lima.EventBooking.API.DTOs;
using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Lima.EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendeeController : Controller
    {
        private readonly AttendeeService _attendeeService;

        public AttendeeController(AttendeeService attendeeService) 
        { 
            _attendeeService = attendeeService;
        }

        [HttpGet("{attendeeId}")]
        public IActionResult GetAttendee(Guid attendeeId) 
        {
            var attendee = _attendeeService.GetAttendeeById(attendeeId);
            if (attendee == null)
            {
                return NotFound(new { message = "Attendee not found"});
            }
            return Ok(attendee);
        }

        [HttpPost]
        public IActionResult CreateAttendee(
            [FromBody] AttendeeDTO attendeeDTO)
        {
            try
            {
                var attendee = new Attendee
                {
                    Id = attendeeDTO.Id,
                    Name = attendeeDTO.Name,
                    Ticket = new TicketType(attendeeDTO.TicketType)
                };
                _attendeeService.CreateAttendee(attendee);
                return Ok(new {
                    message = "Attendee created successfully",
                    attendeeId = attendeeDTO.Id 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllAttendees()
        {
            var attendees = _attendeeService.GetAllAttendees();
            var attendeeDTOs = attendees.Select(a => new AttendeeDTO
            {
                Id = a.Id,
                Name = a.Name,
                TicketType = a.Ticket.Type
            }).ToList();

            return Ok(attendeeDTOs);
        }
    }
}
