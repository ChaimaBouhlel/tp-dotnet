using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityApp.Models;

namespace UniversityApp.Data
{
    public class UniversityAppContext : DbContext
    {
        public UniversityAppContext (DbContextOptions<UniversityAppContext> options)
            : base(options)
        {
        }

        public DbSet<UniversityApp.Models.Student> Student { get; set; } = default!;
    }
}
