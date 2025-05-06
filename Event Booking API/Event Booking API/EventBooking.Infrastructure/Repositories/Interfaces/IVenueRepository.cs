using Lima.EventBooking.Domain.Entities;

namespace Lima.EventBooking.Infrastructure.Repositories.Interfaces
{
    public interface IVenueRepository
    {
        /// <summary>
        /// Get a venue
        /// </summary>
        /// <param name="id">The GUID id of the Venue</param>
        /// <returns>The venue with the provided id.</returns>
        public Venue GetById(Guid id);

        /// <summary>
        /// Save a new venue.
        /// </summary>
        /// <param name="venue">The venue to be saved.</param>
        public void Save(Venue venue);

        /// <summary>
        /// Get all venues.
        /// </summary>
        /// <returns>A collection of all venues.</returns>
        public IEnumerable<Venue> GetAll();
    }
}
