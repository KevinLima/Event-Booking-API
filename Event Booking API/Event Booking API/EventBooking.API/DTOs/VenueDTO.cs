using Lima.EventBooking.Domain.Entities;

namespace Lima.EventBooking.API.DTOs
{
    public class VenueDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }

    public static class VenueDTOExtention
    {
        /// <summary>
        /// Converts <see cref="VenueDTO"/> to a <see cref="Domain.Entities.Venue"/>.
        /// </summary>
        /// <param name="venueDTO">The venueDTO object to convert.</param>
        /// <returns>A new venue object.</returns>
        public static Venue Venue(this VenueDTO venueDTO)
        {
            return new Venue
            {
                Id = Guid.NewGuid(),
                Name = venueDTO.Name,
                Location = venueDTO.Location
            };
        }
    }
}
