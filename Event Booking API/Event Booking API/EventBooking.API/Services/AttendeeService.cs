using Event_Booking_API.EventBooking.Domain.Aggregates;
using Event_Booking_API.EventBooking.Infrastructure.Repositories;
using Lima.EventBooking.Domain.Entities;

namespace Event_Booking_API.EventBooking.API.Services
{
    public class AttendeeService
    {
        private readonly IAttendeeRepository _attendeeRepository;

        public AttendeeService(IAttendeeRepository attendeeRepository)
        {
            _attendeeRepository = attendeeRepository;
        }

        public Attendee GetAttendeeById(Guid id) 
        {
            var attendee = _attendeeRepository.GetById(id);
            return attendee;
        }

        public IEnumerable<Attendee> GetAllAttendees()
        {
            return _attendeeRepository.GetAll();
        }

        public void CreateAttendee(Attendee attendee)
        {
            attendee.Id = Guid.NewGuid();
            var attendeeAggregate = new AttendeeAggregate(attendee);
            _attendeeRepository.Save(attendeeAggregate.Attendee);
        }

    }
}
