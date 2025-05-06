using Lima.EventBooking.Domain.Entities;

namespace Event_Booking_API.EventBooking.Domain.Aggregates
{

    /// <summary>
    /// Represents an aggregate root for an attendee in the event booking domain.
    /// </summary>
    public class AttendeeAggregate
    {
        /// <summary>
        /// Gets the attendee associated with this aggregate.
        /// </summary>
        public Attendee Attendee { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="AttendeeAggregate"/> class.
        /// </summary>
        /// <param name="attendee">The attendee entity to be associated with this aggregate.</param>
        public AttendeeAggregate(Attendee attendee) 
        {
            this.Attendee = attendee;
        }
    }
}
