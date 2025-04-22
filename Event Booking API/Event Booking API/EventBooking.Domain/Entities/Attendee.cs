using System.Net.Sockets;
using Lima.EventBooking.Domain.ValueObjects;

namespace Lima.EventBooking.Domain.Entities
{
    public class Attendee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public TicketType Ticket { get; set; }
    }
}
