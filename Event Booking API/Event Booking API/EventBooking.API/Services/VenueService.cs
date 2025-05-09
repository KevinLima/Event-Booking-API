using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Domain.Aggregates;
using Lima.EventBooking.Infrastructure.Repositories.Interfaces;
using Lima.EventBooking.API.Services.Interfaces;

namespace Lima.EventBooking.API.Services
{
    public class VenueService: IVenueService
    {
        private IVenueRepository _venueRepository;

        /// <summary>
        /// Inject the respository into the service.
        /// </summary>
        /// <param name="venueRepository">The repository to inject.</param>
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

        public Venue GetVenueById(Guid id)
        {
           return _venueRepository.GetById(id);
        }

        public IEnumerable<Venue> GetAllVenues()
        {
            return _venueRepository.GetAll();
        }
    }
}
