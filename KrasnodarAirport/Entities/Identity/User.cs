using KrasnodarAirport.Entities.Airport;
using Microsoft.AspNetCore.Identity;

namespace KrasnodarAirport.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
