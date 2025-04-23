using System;
using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Infrastructure.Repositories;

namespace Lima.EventBooking.Domain.Services
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
            eventBooking.AddAttendee(attendee);
            _eventRepository.Save(eventBooking);
        }

        public Event GetEventById(Guid eventId)
        {
            var eventBooking = _eventRepository.GetById(eventId);
            Console.WriteLine("GetEventById called for ID: " + eventId);
            return eventBooking;
        }

        public void CreateEvent(Event eventBooking)
        {
            eventBooking.Id = Guid.NewGuid();
            _eventRepository.Save(eventBooking);
            Console.WriteLine("CreateEvent called for event: " + eventBooking.Id);
        }

        public IEnumerable<Event> GetAllEvents()
        {
            var events = _eventRepository.GetAll();
            Console.WriteLine("GetAllEvents called. Number of events: " + events.Count());
            return events;
        }
    }
}
