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
    public class DetailsModel : PageModel
    {
        private readonly StudentInformation.Data.StudentInformationContext _context;

        public DetailsModel(StudentInformation.Data.StudentInformationContext context)
        {
            _context = context;
        }

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
    }
}
