namespace Event_Booking_API.EventBooking.Domain.ValueObjects
{
    public class TicketType
    {
        public string Type { get; private set; }

        public TicketType(string type) 
        {
            Type = type;
        }
    }
}
