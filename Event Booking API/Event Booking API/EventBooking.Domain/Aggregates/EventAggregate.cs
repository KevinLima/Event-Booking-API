using Lima.EventBooking.Domain.Entities;

namespace Lima.EventBooking.Domain.Aggregates
{
    /// <summary>
    /// Represents an aggregate root for an event in the event booking domain.
    /// </summary>
    public class EventAggregate
    {
        /// <summary>
        /// The Maximum amount of attendees allowed at an event. 
        /// </summary>
        private const int MaxAttendees = 1000;

        /// <summary>
        /// Gets the event associated with this aggregate.
        /// </summary>
        public Event Event { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventAggregate"/> class.
        /// </summary>
        /// <param name="eventBooking">The event entity to be associated with this aggregate.</param>
        public EventAggregate(Event eventBooking)
        {
            Event = eventBooking;
        }

        /// <summary>
        /// Adds an attendee to a event.
        /// </summary>
        /// <param name="attendee">The attendee that will be added to the event</param>
        /// <exception cref="InvalidOperationException">The event is fully booked</exception>
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