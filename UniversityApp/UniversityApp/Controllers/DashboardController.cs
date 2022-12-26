using Microsoft.AspNetCore.Mvc;

namespace UniversityApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
