using tp3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace tp3.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=C:\\Users\\21697\\Documents\\GL3 chaima\\tp3database.db");
            dbCon.Open();
            using (dbCon)
            {
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM personal_info", dbCon);
                SQLiteDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while(reader.Read())
                    {
                        int id = (int)reader["id"];
                        string firstName = (string)reader["first_name"];
                        string lastName = (string)reader["last_name"];
                        string email = (string)reader["email"];
                        //string dateBirth = (string)reader["date_birth"].ToString();
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];
                        Debug.WriteLine("{0} -- {1} {2} - {3} - {4} - {5} ", id, firstName, lastName, email, image, country);
                    }
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}