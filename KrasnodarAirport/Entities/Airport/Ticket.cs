using KrasnodarAirport.Entities.Identity;

namespace KrasnodarAirport.Entities.Airport
{
    public class Ticket : BaseEntity
    {
        public Flight? Flight { get; set; }
        public User? User { get; set; }
        public TicketStatus Status { get; set; }
        public string Seat { get; set; } = null!;
        
    }
}
