using Lima.EventBooking.Domain.Entities;

namespace Lima.EventBooking.Domain.Aggregates
{
    public class VenueAggregate
    {
        public Venue Venue { get; private set; }

        public VenueAggregate(Venue venue) 
        {
            this.Venue = venue;
        }
    }
}
