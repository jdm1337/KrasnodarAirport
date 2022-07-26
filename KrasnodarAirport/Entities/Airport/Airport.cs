namespace KrasnodarAirport.Entities.Airport
{
    public class Airport : BaseEntity
    {
        public string Code { get; set; } = null!;
        public ICollection<Flight> Flights { get; set; }
        public Airport(string code)
        {
            Code = code;
        }
    }
}
