using Lima.EventBooking.Infrastructure.Repositories;
using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Domain.Aggregates;

namespace Lima.EventBooking.API.Services
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
            venue.Id = Guid.NewGuid();
            var venueAggregate = new VenueAggregate(venue);
            _venueRepository.Save(venueAggregate.Venue);
        }

        public IEnumerable<Venue> GetAllVenues() 
        { 
            return _venueRepository.GetAll();
        }

        public Venue GetVenueById(Guid id)
        {
           return _venueRepository.GetById(id);
        }
    }
}
