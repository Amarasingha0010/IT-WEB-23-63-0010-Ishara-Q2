using Microsoft.EntityFrameworkCore;
using StudentInformation.Model;

namespace StudentInformation.Data
{
    public class StudentInformationContext : DbContext
    {
        public StudentInformationContext(DbContextOptions<StudentInformationContext> options)
            : base(options)
        {
        }

        public DbSet<Student_Info> Student_Info { get; set; }
        public DbSet<Course_Info> Course_Info { get; set; }
    }
}
