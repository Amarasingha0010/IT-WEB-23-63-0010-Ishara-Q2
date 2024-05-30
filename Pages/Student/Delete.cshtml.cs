using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentInformation.Data;
using StudentInformation.Model;

namespace StudentInformation.Pages.Student
{
    public class DeleteModel : PageModel
    {
        private readonly StudentInformation.Data.StudentInformationContext _context;

        public DeleteModel(StudentInformation.Data.StudentInformationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student_Info Student_Info { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_info = await _context.Student_Info.FirstOrDefaultAsync(m => m.StudentID == id);

            if (student_info == null)
            {
                return NotFound();
            }
            else
            {
                Student_Info = student_info;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_info = await _context.Student_Info.FindAsync(id);
            if (student_info != null)
            {
                Student_Info = student_info;
                _context.Student_Info.Remove(Student_Info);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
