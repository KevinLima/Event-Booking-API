using Lima.EventBooking.Domain.Entities;

namespace Lima.EventBooking.Infrastructure.Repositories.Interfaces
{
    public interface IAttendeeRepository
    {
        /// <summary>
        /// Get an attendee.
        /// </summary>
        /// <param name="id">The GUID id of an attendee.</param>
        /// <returns>The attendee with the id. </returns>
        public Attendee GetById(Guid id);

        /// <summary>
        /// Save an attendee.
        /// </summary>
        /// <param name="attendee">The new attendee.</param>
        public void Save(Attendee attendee);

        /// <summary>
        /// Get all attendees.
        /// </summary>
        /// <returns>A collection of attendees.</returns>
        public IEnumerable<Attendee> GetAll();

    }
}
