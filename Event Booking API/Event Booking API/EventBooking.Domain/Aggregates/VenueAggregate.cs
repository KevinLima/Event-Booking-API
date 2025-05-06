using Lima.EventBooking.Domain.Entities;

namespace Lima.EventBooking.Domain.Aggregates
{
    /// <summary>
    /// Represents an aggregate root for an venue in the event booking domain.
    /// </summary>
    public class VenueAggregate
    {
        /// <summary>
        /// Gets the venue associated with this aggregate.
        /// </summary>
        public Venue Venue { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VenueAggregate"/> class.
        /// </summary>
        /// <param name="venue">The venue entity to be associated with this aggregate.</param>
        public VenueAggregate(Venue venue) 
        {
            this.Venue = venue;
        }
    }
}
