using Event_Booking_API.EventBooking.Domain.Entities;

public class EventAggregate
{
    public Event Event { get; private set; }

    public EventAggregate(Event eventBooking)
    {
        Event = eventBooking;
    }

    public void AddAttendee(Attendee attendee)
    {
        Event.Attendees.Add(attendee);
    }
}

