using Microsoft.AspNetCore.Mvc;

namespace KrasnodarAirport.Controllers
{
    public class TicketController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
