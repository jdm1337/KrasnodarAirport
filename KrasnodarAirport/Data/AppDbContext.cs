using KrasnodarAirport.Entities.Airport;
using KrasnodarAirport.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KrasnodarAirport.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
