using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Domain.ValueObjects;

namespace Lima.EventBooking.API.DTOs
{
    public class EventDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public VenueDTO Venue { get; set; }
        public List<AttendeeDTO> Attendees { get; set; }
    }

    public static class EventDTOExtentions
    {
        /// <summary>
        /// Coverts a <see cref="EventDTO"/> to a <see cref="Domain.Entities.Event"/>.
        /// </summary>
        /// <param name="eventDto">The eventDTO to convert.</param>
        /// <returns>A new event object.</returns>
        public static Event Event(this EventDTO eventDto)
        {
            return new Event
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
        }
    }
}
