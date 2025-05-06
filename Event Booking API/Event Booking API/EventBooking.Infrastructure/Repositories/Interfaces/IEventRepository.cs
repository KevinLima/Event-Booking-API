using Lima.EventBooking.Domain.Entities;

namespace Lima.EventBooking.Infrastructure.Repositories.Interfaces
{
    public interface IEventRepository
    {
        /// <summary>
        /// Get a booked event. 
        /// </summary>
        /// <param name="id">The GUID id of the event.</param>
        /// <returns>The booked event with the provided id.</returns>
        public Event GetById(Guid id);

        /// <summary>
        /// Book a new event.
        /// </summary>
        /// <param name="eventBooking">The event to be booked.</param>
        public void Save(Event eventBooking);

        /// <summary>
        /// Get all events.
        /// </summary>
        /// <returns>A collection of all events.</returns>
        public IEnumerable<Event> GetAll();
    }
 }
