using Microsoft.AspNetCore.Mvc;

namespace GoodTrip.Controllers
{
    public class DestinosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
