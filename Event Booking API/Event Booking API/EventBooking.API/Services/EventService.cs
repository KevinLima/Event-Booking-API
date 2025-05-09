using System;
using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Domain.Aggregates;
using Lima.EventBooking.Infrastructure.Repositories.Interfaces;
using Lima.EventBooking.API.Services.Interfaces;

namespace Lima.EventBooking.API.Services
{

    public class EventService: IEventService
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

        public void BookEvent(Guid eventId, Attendee attendee)
        {
            var eventBooking = _eventRepository.GetById(eventId);
            var eventAggregate = new EventAggregate(eventBooking);
            eventAggregate.AddAttendee(attendee);
            _eventRepository.Save(eventAggregate.Event);
        }

        public Event GetEventById(Guid eventId)
        {
            var eventBooking = _eventRepository.GetById(eventId);
            return eventBooking;
        }

        public void CreateEvent(Event eventBooking)
        {
            eventBooking.Id = Guid.NewGuid();
            var eventAggregate = new EventAggregate(eventBooking);
            _eventRepository.Save(eventAggregate.Event);
        }

        public IEnumerable<Event> GetAllEvents()
        {
           return _eventRepository.GetAll();
        }
    }
}
