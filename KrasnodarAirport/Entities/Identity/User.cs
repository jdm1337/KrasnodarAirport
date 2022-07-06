using KrasnodarAirport.Entities.Airport;
using Microsoft.AspNetCore.Identity;

namespace KrasnodarAirport.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Passport { get; set; } = null!;
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
