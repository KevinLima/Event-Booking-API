using Event_Booking_API.EventBooking.Domain.Aggregates;
using Lima.EventBooking.API.Services.Interfaces;
using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Infrastructure.Repositories.Interfaces;

namespace Event_Booking_API.EventBooking.API.Services
{
    public class AttendeeService: IAttendeeService
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
