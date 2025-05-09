using Lima.EventBooking.Domain.Entities;

namespace Lima.EventBooking.API.Services.Interfaces
{
    public interface IVenueService
    {
        /// <inheritdoc cref="IVenueRepository.Save(Venue)" />
        public void CreateVenue(Venue venue);

        /// <inheritdoc cref="IVenueRepository.GetById(Guid)" />
        public Venue GetVenueById(Guid id);

        /// <inheritdoc cref="IVenueRepository.GetAll" />
        public IEnumerable<Venue> GetAllVenues();
    }
}
