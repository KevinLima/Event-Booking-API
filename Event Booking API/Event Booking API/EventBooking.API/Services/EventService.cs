using System;
using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Domain.Aggregates;
using Lima.EventBooking.Infrastructure.Repositories.Interfaces;

namespace Lima.EventBooking.API.Services
{

    public class EventService
    {
        private readonly IEventRepository _eventRepository;

        /// <summary>
        /// Inject the respository into the service.
        /// </summary>
        /// <param name="eventRepository">The repository to inject.</param>
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

       /// <summary>
       /// Add an attendee to a event. 
       /// </summary>
       /// <param name="eventId">Guid id of the event.</param>
       /// <param name="attendee">The attendee to be booked to the event.</param>
        public void BookEvent(Guid eventId, Attendee attendee)
        {
            var eventBooking = _eventRepository.GetById(eventId);
            var eventAggregate = new EventAggregate(eventBooking);
            eventAggregate.AddAttendee(attendee);
            _eventRepository.Save(eventAggregate.Event);
        }

        /// <inheritdoc cref="IEventRepository.GetById(Guid)" />
        public Event GetEventById(Guid eventId)
        {
            var eventBooking = _eventRepository.GetById(eventId);
            return eventBooking;
        }

        /// <inheritdoc cref="IEventRepository.Save(Event)" />
        public void CreateEvent(Event eventBooking)
        {
            eventBooking.Id = Guid.NewGuid();
            var eventAggregate = new EventAggregate(eventBooking);
            _eventRepository.Save(eventAggregate.Event);
        }

        /// <inheritdoc cref="IEventRepository.GetAll" />
        public IEnumerable<Event> GetAllEvents()
        {
           return _eventRepository.GetAll();
        }
    }
}
