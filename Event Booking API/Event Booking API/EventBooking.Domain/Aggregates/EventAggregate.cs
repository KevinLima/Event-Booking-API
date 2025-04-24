using Lima.EventBooking.Domain.Entities;

namespace Lima.EventBooking.Domain.Aggregates
{
    public class EventAggregate
    {
        private const int MaxAttendees = 1000;
        public Event Event { get; private set; }

        public EventAggregate(Event eventBooking)
        {
            Event = eventBooking;
        }

        public void AddAttendee(Attendee attendee)
        {
            if (Event.Attendees.Count >= MaxAttendees)
            {
                throw new InvalidOperationException(
                    "Cannot add attendee, maximum amount has been reached");
            }
            Event.Attendees.Add(attendee);
        }
    }
}