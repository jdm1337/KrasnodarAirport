namespace KrasnodarAirport.Entities.Airport
{
    public class Airplane: BaseEntity
    {
        public string Model { get; set; } = null!;
        public int SeatsAmount { get; set; }
        public Airplane(string model, int seatsAmount)
        {
            Model = model;
            SeatsAmount = seatsAmount;
        }
    }
}
