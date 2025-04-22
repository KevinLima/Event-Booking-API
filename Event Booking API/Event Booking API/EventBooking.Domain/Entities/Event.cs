using Lima.EventBooking.Domain.ValueObjects;

namespace Lima.EventBooking.Domain.Entities
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
