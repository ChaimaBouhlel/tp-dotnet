using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using tp4.Models;

namespace tp4.Data
{
    public class UniversityContext : DbContext
    {
        private UniversityContext(DbContextOptions o): base(o) { }

        private static UniversityContext? universityContextInstance = null;

        public static UniversityContext Instantiate_UniversityContext()
        {
            if (universityContextInstance == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\21697\\Documents\\GL3 chaima\\tp4database.db");
                Debug.WriteLine("Instantiation");
                Debug.WriteLine("Instantiation");
                Debug.WriteLine("Instantiation");
                Debug.WriteLine("Instantiation");
                universityContextInstance = new UniversityContext(optionsBuilder.Options);
                return universityContextInstance;
            }
            else
            {
                Debug.WriteLine("Already instantiated!");
                return universityContextInstance;
            }
        }
        public DbSet<Student> Student { get; set; }

    }
}
