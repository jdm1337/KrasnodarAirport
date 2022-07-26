using KrasnodarAirport.Entities.Airport;
using KrasnodarAirport.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace KrasnodarAirport.Data
{
    public class SeedDataService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly AppDbContext _appDbContext;
        public SeedDataService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            AppDbContext appDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _appDbContext = appDbContext;
        }
        public async Task SeedInitIdentityAsync()
        {
            if (!_appDbContext.Users.Any())
            {
                var adminRole = new Role
                {
                    Name = "Admin",
                };

                await _roleManager.CreateAsync(adminRole);
                
                var adminUser = new User()
                {
                    Email = "sstaramaly@gmail.com",
                    UserName = "Admin",
                    EmailConfirmed = true
                };

                await _userManager.CreateAsync(adminUser, "Qwerty1234!");


                //seed common user role
                var commonRole = new Role()
                {
                    Name = "CommonUser",
                    
                };
                await _roleManager.CreateAsync(commonRole);

                var commonUser = new User()
                {
                    Email = "user@user.com",
                    UserName = "DemoUser",
                    EmailConfirmed = true
                };

                await _userManager.CreateAsync(commonUser, "Qwerty1234!");

                await _userManager.AddToRoleAsync(commonUser, "CommonUser");

                await _userManager.CreateAsync(adminUser, "Qwerty1234!");

                await _userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
        public async Task SeedInitAirportEntityAsync()
        {
            if (!_appDbContext.Flights.Any())
            {
                var airport = new Airport("DME");
                var airplane = new Airplane("Airbus A320", 140);
                int periodMonths = 3;
                var flight = new Flight()
                {
                    Country = "Россия",
                    City = "Москва",
                    Airport = airport,
                    Airplane = airplane,
                    PublishDate = DateTime.UtcNow.Date,
                    ExpiryDate = DateTime.UtcNow.AddMonths(3).Date,
                    Period = periodMonths,
                    FirstFlight = DateTime.UtcNow.AddDays(1).Date,
                    FlightReals = new List<FlightReal>() 
                   
                };
                DateTime time = flight.FirstFlight;
                while(time < flight.ExpiryDate)
                {
                    var flightReal = new FlightReal()
                    {
                        DepartureTime = new DateTime(time.Year, time.Month, time.Day, time.Hour, 0, 0),
                        FlightTime = new DateTime(0, 0, 0, 4, 30, 0),
                        FlightNumber = "987654321",
                        Tickets = new List<Ticket>()
                    };
                    var tickets = new List<Ticket>();
                    for(int row = 1; row <= flight.Airplane.SeatsAmount / 6; row++)
                    {
                        tickets.Add(new Ticket() { Seat = $"{row}A" });
                        tickets.Add(new Ticket() { Seat = $"{row}B" });
                        tickets.Add(new Ticket() { Seat = $"{row}C" });
                        tickets.Add(new Ticket() { Seat = $"{row}D" });
                        tickets.Add(new Ticket() { Seat = $"{row}E" });
                        tickets.Add(new Ticket() { Seat = $"{row}F" });
                    }
                    flightReal.Tickets = tickets;

                    flight.FlightReals.Add(flightReal);
                    time.AddDays(periodMonths);

                }
                await _appDbContext.Flights.AddAsync(flight);

                await _appDbContext.SaveChangesAsync();
            }
        }


    }
}
