using Microsoft.AspNetCore.Mvc;

namespace KrasnodarAirport.Controllers
{
    public class FlightController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
