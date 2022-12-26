using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace UniversityApp.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        public IActionResult Index()
        {
            return View("Index");
        }
        // 
        // GET: /Student/Welcome/ 
        public IActionResult Welcome(string name, int number)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["Number"] = number;   
            return View();
            //return $"Hello {name}, here is your number: {number}";
            //return "This is the Welcome action method...";
        }
    }
}
