namespace KrasnodarAirport.Entities.Airport
{
    public class Flight : BaseEntity
    {
        public DateTime DepartureTime { get; set; }
        public string Direction { get; set; } = null!;
        public DateTime FlightTime { get; set; }
        public string FlightNumber { get; set; } = null!;
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
