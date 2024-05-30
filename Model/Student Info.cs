using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInformation.Model
{

        public class Student_Info
    {
        [Key]
        public int StudentID { get; set; }  // Primary Key
        public string Name { get; set; } = string.Empty;  // Provide default value
        public string? City { get; set; }  // Nullable property
        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public Course_Info? Course { get; set; }  // Nullable navigation property
    }

}

