using System.Net.Sockets;
using Event_Booking_API.EventBooking.Domain.ValueObjects;

namespace Event_Booking_API.EventBooking.Domain.Entities
{
    public class Attendee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public TicketType Ticket { get; set; }
    }
}
