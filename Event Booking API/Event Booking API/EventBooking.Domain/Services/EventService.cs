using System;
using Event_Booking_API.EventBooking.Domain.Entities;
using Event_Booking_API.EventBooking.Infrastructure.Repositories;

namespace Event_Booking_API.EventBooking.Domain.Services
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
