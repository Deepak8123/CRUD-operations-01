using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AspCodeFirst_01.Models
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Student> StudentsDB { get; set; }
    }
}
