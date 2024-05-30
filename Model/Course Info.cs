using System.ComponentModel.DataAnnotations;

namespace StudentInformation.Model
{
    public class Course_Info
    {
        [Key]
        public int CourseID { get; set; }  // Primary Key
        public string CourseName { get; set; } = string.Empty;  // Provide default value
        public string LecturerName { get; set; } = string.Empty;  // Provide default value
    }
}
