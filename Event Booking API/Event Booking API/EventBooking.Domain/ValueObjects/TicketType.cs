namespace Lima.EventBooking.Domain.ValueObjects
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
