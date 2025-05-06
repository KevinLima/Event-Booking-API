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

        /// <summary>
        /// Injectable service for this controllers.
        /// </summary>
        /// <param name="attendeeService">The service that wil be injected.</param>
        public AttendeeController(AttendeeService attendeeService) 
        { 
            _attendeeService = attendeeService;
        }

        /// <summary>
        /// Gets the attendee associated with the id. 
        /// </summary>
        /// <param name="attendeeId">The id of the attendee.</param>
        /// <returns>A <see cref="ObjectResult"/>, and the attendee if it was found.</returns>
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

        /// <summary>
        /// Create a new attendee
        /// </summary>
        /// <param name="attendeeDTO">The DTO of the new Attendee</param>
        /// <returns>A object result, and the attendee if it was created.</returns>
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

        /// <summary>
        /// Gets all attendees.
        /// </summary>
        /// <returns>A <see cref="ObjectResult"/> and a list of attendees.</returns>
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
