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
    }
}
