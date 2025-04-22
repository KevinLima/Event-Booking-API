using Event_Booking_API.EventBooking.Domain.Entities;

namespace Event_Booking_API.EventBooking.Infrastructure.Repositories
{
    public interface IEventRepository
    {
        Event GetById(Guid id);
        void Save(Event eventBooking);
        }


    }
