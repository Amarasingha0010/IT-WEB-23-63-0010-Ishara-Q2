using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentInformation.Data;
using StudentInformation.Model;

namespace StudentInformation.Pages.Course
{
    public class EditModel : PageModel
    {
        private readonly StudentInformation.Data.StudentInformationContext _context;

        public EditModel(StudentInformation.Data.StudentInformationContext context)
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

            var course_info =  await _context.Course_Info.FirstOrDefaultAsync(m => m.CourseID == id);
            if (course_info == null)
            {
                return NotFound();
            }
            Course_Info = course_info;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Course_Info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Course_InfoExists(Course_Info.CourseID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Course_InfoExists(int id)
        {
            return _context.Course_Info.Any(e => e.CourseID == id);
        }
    }
}
