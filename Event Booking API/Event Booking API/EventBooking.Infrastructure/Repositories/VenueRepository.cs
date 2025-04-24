using System.Xml.Linq;
using Lima.EventBooking.Domain.Entities;

namespace Lima.EventBooking.Infrastructure.Repositories
{
    public class VenueRepository: IVenueRepository
    {
        private readonly Dictionary<string, Venue> _venues = new Dictionary<string, Venue>();

        public Venue GetByName(string name)
        {
            _venues.TryGetValue(name, out var venue);
            return venue;
        }

        public void Save(Venue venue)
        {
            _venues[venue.Name] = venue;
        }

        public IEnumerable<Venue> GetAll()
        {
            return _venues.Values;
        }
    }
}
