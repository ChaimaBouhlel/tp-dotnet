using tp3.Models;
using Microsoft.AspNetCore.Mvc;

namespace tp3.Controllers
{
    public class PersonController : Controller
    {

        [Route("Person/{id:int}")]
        public IActionResult Index(int id)
        {
            return View(Personal_info.GetPerson(id));
        }

        [Route("Person/all")]
        public IActionResult all()
        {
            return View(Personal_info.GetAllPerson());
        }
        [HttpGet]
        public IActionResult search()
        {
            ViewBag.notFound = false;
            return View();
        }
        [HttpPost]
        public IActionResult search(String first_name, String country)
        {
            List<Person> list = Personal_info.GetAllPerson();
            Person person = list.Find(x => x.first_name == first_name && x.country == country);

            if (person != null)
            {
                return Redirect(person.id.ToString());
            }

            ViewBag.notFound = true;
            return View();
        }
    }
}
