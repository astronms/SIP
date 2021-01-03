using Microsoft.AspNetCore.Mvc;

namespace GoogleMaps.Controllers
{
    public class GoogleMapsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}