namespace KrasnodarAirport.Entities.Airport
{
    public class Flight : BaseEntity
    {
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public Airport? Airport { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Period { get; set; }
        public DateTime FirstFlight { get; set; }
        public ICollection<FlightReal>? FlightReals { get; set; }
    }
}
