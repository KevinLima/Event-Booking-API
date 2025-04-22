namespace Lima.EventBooking.Domain.ValueObjects
{
    public class EventDate
    {
        public DateTime Date { get; private set; }

        public EventDate(DateTime date)
        {
            Date = date;
        }
    }
}
