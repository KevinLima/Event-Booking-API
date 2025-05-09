using Lima.EventBooking.Domain.Entities;

namespace Lima.EventBooking.API.Services.Interfaces
{
    public interface IEventService
    {
        /// <summary>
        /// Add an attendee to a event. 
        /// </summary>
        /// <param name="eventId">Guid id of the event.</param>
        /// <param name="attendee">The attendee to be booked to the event.</param>
        public void BookEvent(Guid eventId, Attendee attendee);

        /// <inheritdoc cref="IEventRepository.GetById(Guid)" />
        public Event GetEventById(Guid eventId);

        /// <inheritdoc cref="IEventRepository.Save(Event)" />
        public void CreateEvent(Event eventBooking);

        /// <inheritdoc cref="IEventRepository.GetAll" />
        public IEnumerable<Event> GetAllEvents();
    }
}
