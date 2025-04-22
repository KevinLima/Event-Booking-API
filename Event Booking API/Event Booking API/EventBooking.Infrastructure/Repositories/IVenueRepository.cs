using Event_Booking_API.EventBooking.Domain.Entities;

namespace Event_Booking_API.EventBooking.Infrastructure.Repositories
{
    public interface IVenueRepository
    {
        Venue GetById(Guid id);
        void Save(Venue venue);
    }
}
