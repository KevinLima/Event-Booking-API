using System;
using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Infrastructure.Repositories;
using Lima.EventBooking.Domain.Aggregates;

namespace Lima.EventBooking.API.Services
{

    public class EventService
    {
        private readonly IEventRepository _eventRepository;

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
            var events = _eventRepository.GetAll();
            return events;
        }
    }
}
