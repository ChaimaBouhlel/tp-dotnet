using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tp4.Data;
using tp4.Models;

namespace tp4.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            StudentRepository studentRepository = new StudentRepository(universityContext);
            List<String> students = (List<string>)studentRepository.GetCourses();
            foreach (String s in students)
                Debug.WriteLine(s);
            return View(students);
        }


        public IActionResult GetCourse(string id)
        {
            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            StudentRepository studentRepository = new StudentRepository(universityContext);
            IEnumerable<Student> res = studentRepository.Find(v => v.course.ToLower() ==    id.ToLower());
            ViewBag.id = id;
            foreach (Student s in res)
                Debug.WriteLine(s.first_name);
            //Debug.WriteLine(result.Count());
            return View(res);
        }
    }
}
