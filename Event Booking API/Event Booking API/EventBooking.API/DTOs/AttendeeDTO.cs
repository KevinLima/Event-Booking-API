using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Domain.ValueObjects;

namespace Lima.EventBooking.API.DTOs
{
    public class AttendeeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string TicketType { get; set; }
    }

    public static class AttendeeDTOExtensions
    {
        /// <summary>
        /// Convert <see cref="AttendeeDTO"/> to <see cref="Domain.Entities.Attendee"/>.
        /// </summary>
        /// <param name="attendeeDTO">The attendeeDTO to covert</param>
        /// <returns>The new attendee object.</returns>
        public static Attendee Attendee(this AttendeeDTO attendeeDTO)
        {
            return new Attendee
            {
                Id = attendeeDTO.Id,
                Name = attendeeDTO.Name,
                Ticket = new TicketType(attendeeDTO.TicketType)
            };
        }
    }
}
