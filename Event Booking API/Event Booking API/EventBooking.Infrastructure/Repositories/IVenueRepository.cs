using Lima.EventBooking.Domain.Entities;

namespace Lima.EventBooking.Infrastructure.Repositories
{
    public interface IVenueRepository
    {
        Venue GetByName(string name);
        void Save(Venue venue);
        IEnumerable<Venue> GetAll();
    }
}
