using System.Xml.Linq;
using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Infrastructure.Repositories.Interfaces;

namespace Lima.EventBooking.Infrastructure.Repositories
{
    public class VenueRepository: IVenueRepository
    {
        private readonly Dictionary<Guid, Venue> _venues = 
            new Dictionary<Guid, Venue>();

        public Venue GetById(Guid id)
        {
            _venues.TryGetValue(id, out var venue);
            return venue;
        }

        public void Save(Venue venue)
        {
            _venues[venue.Id] = venue;
        }

        public IEnumerable<Venue> GetAll()
        {
            return _venues.Values;
        }
    }
}
