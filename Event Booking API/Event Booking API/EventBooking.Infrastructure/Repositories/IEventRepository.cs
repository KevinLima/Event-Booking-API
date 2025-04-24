using Lima.EventBooking.Domain.Entities;

namespace Lima.EventBooking.Infrastructure.Repositories
{
    public interface IEventRepository
    {
        Event GetById(Guid id);
        void Save(Event eventBooking);
        IEnumerable<Event> GetAll();
    }
 }
