namespace Lima.EventBooking.API.DTOs
{
    public class EventDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public VenueDTO Venue { get; set; }
        public List<AttendeeDTO> Attendees { get; set; }
    }
}
