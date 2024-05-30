using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentInformation.Data;
using StudentInformation.Model;

namespace StudentInformation.Pages.Course
{
    public class DeleteModel : PageModel
    {
        private readonly StudentInformation.Data.StudentInformationContext _context;

        public DeleteModel(StudentInformation.Data.StudentInformationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course_Info Course_Info { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course_info = await _context.Course_Info.FirstOrDefaultAsync(m => m.CourseID == id);

            if (course_info == null)
            {
                return NotFound();
            }
            else
            {
                Course_Info = course_info;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course_info = await _context.Course_Info.FindAsync(id);
            if (course_info != null)
            {
                Course_Info = course_info;
                _context.Course_Info.Remove(Course_Info);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
