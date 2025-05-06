using Event_Booking_API.EventBooking.Domain.Aggregates;
using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Infrastructure.Repositories.Interfaces;

namespace Event_Booking_API.EventBooking.API.Services
{
    public class AttendeeService
    {
        private readonly IAttendeeRepository _attendeeRepository;

        /// <summary>
        /// Inject the respository into the service.
        /// </summary>
        /// <param name="attendeeRepository">The repository to inject.</param>
        public AttendeeService(IAttendeeRepository attendeeRepository)
        {
            _attendeeRepository = attendeeRepository;
        }

        /// <inheritdoc cref="IAttendeeRepository.GetById(Guid)" />
        public Attendee GetAttendeeById(Guid id) 
        {
            var attendee = _attendeeRepository.GetById(id);
            return attendee;
        }

        /// <inheritdoc cref="IAttendeeRepository.GetAll()" />
        public IEnumerable<Attendee> GetAllAttendees()
        {
            return _attendeeRepository.GetAll();
        }

        /// <inheritdoc cref="IAttendeeRepository.Save(Attendee)" />
        public void CreateAttendee(Attendee attendee)
        {
            attendee.Id = Guid.NewGuid();
            var attendeeAggregate = new AttendeeAggregate(attendee);
            _attendeeRepository.Save(attendeeAggregate.Attendee);
        }

    }
}
