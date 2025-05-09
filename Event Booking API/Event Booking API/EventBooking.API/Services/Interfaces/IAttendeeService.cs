using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Infrastructure.Repositories.Interfaces;

namespace Lima.EventBooking.API.Services.Interfaces
{
    public interface IAttendeeService
    {
        /// <inheritdoc cref="IAttendeeRepository.GetById(Guid)" />
        public Attendee GetAttendeeById(Guid id);

        /// <inheritdoc cref="IAttendeeRepository.Save(Attendee)" />
        public void CreateAttendee(Attendee attendee);

        /// <inheritdoc cref="IAttendeeRepository.GetAll()" />
        public IEnumerable<Attendee> GetAllAttendees();
    }
}
