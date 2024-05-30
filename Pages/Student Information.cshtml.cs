using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentInformation.Data;
using StudentInformation.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StudentInformation.Pages
{
    public class StudentInfoModel : PageModel
    {
        private readonly StudentInformationContext _context;

        public StudentInfoModel(StudentInformationContext context)
        {
            _context = context;
        }

        public IList<Student_Info> Students { get; set; }

        public async Task OnGetAsync()
        {
            Students = await _context.Student_Info
                .Include(s => s.Course)
                .ToListAsync();

            // Debugging
            Debug.WriteLine("Students Count: " + Students.Count);
            foreach (var student in Students)
            {
                Debug.WriteLine($"Student: {student.Name}, Course: {student.Course.CourseName}");
            }
        }
    }
}
