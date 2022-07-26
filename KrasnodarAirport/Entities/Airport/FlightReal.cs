﻿namespace KrasnodarAirport.Entities.Airport
{
    public class FlightReal : BaseEntity
    {
        public DateTime DepartureTime { get; set; }
        public DateTime FlightTime { get; set; }
        public string FlightNumber { get; set; } = null!;
        public Flight? Flight { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
