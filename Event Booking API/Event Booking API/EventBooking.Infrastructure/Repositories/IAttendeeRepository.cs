using Lima.EventBooking.Domain.Entities;

namespace Event_Booking_API.EventBooking.Infrastructure.Repositories
{
    public interface IAttendeeRepository
    {
        Attendee GetById(Guid id);
        void Save(Attendee attendee);
        IEnumerable<Attendee> GetAll();

    }
}
