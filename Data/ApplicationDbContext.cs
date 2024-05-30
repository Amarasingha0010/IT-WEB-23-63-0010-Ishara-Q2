using Microsoft.EntityFrameworkCore;
using StudentInformation.Model;

namespace StudentInformation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student_Info> Students { get; set; }
        public DbSet<Course_Info> Courses { get; set; }
    }
}
