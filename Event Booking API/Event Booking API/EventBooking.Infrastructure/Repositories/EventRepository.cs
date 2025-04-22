using Lima.EventBooking.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Lima.EventBooking.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly Dictionary<Guid, Event> _events = 
            new Dictionary<Guid, Event>();

        public Event GetById(Guid id)
        {
            _events.TryGetValue(id, out var eventBooking);
            return eventBooking;
        }

        public void Save(Event eventBooking)
        {
            _events[eventBooking.Id] = eventBooking;
        }

        public IEnumerable<Event> GetAll()
        {
            return _events.Values;
        }
    }
}
