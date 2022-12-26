using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tp4.Data;
using tp4.Models;

namespace tp4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            UniversityContext context = UniversityContext.Instantiate_UniversityContext();
            List<Student> s = context.Student.ToList();
            return View(s);
        }

        public IActionResult Privacy()
        {
            UniversityContext anotherContext= UniversityContext.Instantiate_UniversityContext();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}