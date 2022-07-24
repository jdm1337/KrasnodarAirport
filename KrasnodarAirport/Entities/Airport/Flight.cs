namespace KrasnodarAirport.Entities.Airport
{
    public class Flight : BaseEntity
    {
        public string Direction { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Period { get; set; }
        public DateTime FirstFlight { get; set; }
        public ICollection<FlightReal>? FlightReals { get; set; }
    }
}
