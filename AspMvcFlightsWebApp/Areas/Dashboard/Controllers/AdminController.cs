using Microsoft.AspNetCore.Mvc;

namespace AspMvcFlightsWebApp.Areas.Dashboard.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
