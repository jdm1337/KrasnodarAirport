namespace KrasnodarAirport.Entities.Airport
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is BaseEntity entity &&
                   Id == entity.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
