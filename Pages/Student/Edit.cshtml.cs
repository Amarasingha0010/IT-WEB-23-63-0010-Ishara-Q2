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

namespace StudentInformation.Pages.Student
{
    public class EditModel : PageModel
    {
        private readonly StudentInformation.Data.StudentInformationContext _context;

        public EditModel(StudentInformation.Data.StudentInformationContext context)
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

            var student_info =  await _context.Student_Info.FirstOrDefaultAsync(m => m.StudentID == id);
            if (student_info == null)
            {
                return NotFound();
            }
            Student_Info = student_info;
           ViewData["CourseID"] = new SelectList(_context.Set<Course_Info>(), "CourseID", "CourseID");
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

            _context.Attach(Student_Info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Student_InfoExists(Student_Info.StudentID))
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

        private bool Student_InfoExists(int id)
        {
            return _context.Student_Info.Any(e => e.StudentID == id);
        }
    }
}
