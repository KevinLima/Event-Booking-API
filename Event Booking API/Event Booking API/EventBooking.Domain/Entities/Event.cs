using Event_Booking_API.EventBooking.Domain.ValueObjects;

namespace Event_Booking_API.EventBooking.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EventDate Date { get; set; }
        public Venue Venue { get; set; }
        public List<Attendee> Attendees { get; set; }

        public Event()
        {
            Attendees = new List<Attendee>();
        }

        public void AddAttendee(Attendee attendee)
        {
            Attendees.Add(attendee);
        }
    }
}
