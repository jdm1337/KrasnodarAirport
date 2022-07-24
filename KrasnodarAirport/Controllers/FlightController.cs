using Microsoft.AspNetCore.Mvc;

namespace KrasnodarAirport.Controllers
{
    public class FlightController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
