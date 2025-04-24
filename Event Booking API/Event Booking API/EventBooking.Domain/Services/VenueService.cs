using Lima.EventBooking.Infrastructure.Repositories;
using Lima.EventBooking.Domain.Entities;

namespace Lima.EventBooking.Domain.Services
{
    public class VenueService
    {
        private IVenueRepository _venueRepository;

        public VenueService(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }

        public void CreateVenue(Venue venue)
        {
            _venueRepository.Save(venue);
        }

        public IEnumerable<Venue> GetAllVenues() 
        { 
            return _venueRepository.GetAll();
        }

        public Venue GetVenueByName(string name)
        {
           return _venueRepository.GetByName(name);
        }
    }
}
