using KrasnodarAirport.Entities.Identity;

namespace KrasnodarAirport.Entities.Airport
{
    public class Ticket : BaseEntity
    {
        public FlightReal? FlightReal { get; set; }
        public User? User { get; set; }
        public TicketStatus Status { get; set; }
        public string Seat { get; set; } = null!;
        
    }
}
