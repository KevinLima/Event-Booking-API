using Lima.EventBooking.Domain.Entities;

namespace Lima.EventBooking.Infrastructure.Repositories
{
    public interface IVenueRepository
    {
        Venue GetById(Guid id);
        void Save(Venue venue);
    }
}
