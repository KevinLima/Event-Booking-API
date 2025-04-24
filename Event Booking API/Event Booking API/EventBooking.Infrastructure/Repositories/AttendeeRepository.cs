using Event_Booking_API.EventBooking.Domain.Aggregates;
using Lima.EventBooking.Domain.Entities;

namespace Event_Booking_API.EventBooking.Infrastructure.Repositories
{
    public class AttendeeRepository: IAttendeeRepository
    {

        private readonly Dictionary<Guid, Attendee> _attendees =
            new Dictionary<Guid, Attendee>();

        public Attendee GetById(Guid id)
        {
            _attendees.TryGetValue(id, out var attendee);
            return attendee;
        }

        public void Save(Attendee attendee)
        {
            _attendees[attendee.Id] = attendee;
        }

        public IEnumerable<Attendee> GetAll() 
        {
            return _attendees.Values;
        }

    }
}
