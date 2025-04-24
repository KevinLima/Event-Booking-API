using Lima.EventBooking.Domain.Entities;

namespace Event_Booking_API.EventBooking.Domain.Aggregates
{
    public class AttendeeAggregate
    {
        public Attendee Attendee { get; private set; }

        public AttendeeAggregate(Attendee attendee) 
        {
            this.Attendee = attendee;
        }
    }
}
