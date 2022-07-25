using Microsoft.AspNetCore.Mvc;

namespace KrasnodarAirport.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
