using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentInformation.Data;
using StudentInformation.Model;

namespace StudentInformation.Pages.Course
{
    public class CreateModel : PageModel
    {
        private readonly StudentInformation.Data.StudentInformationContext _context;

        public CreateModel(StudentInformation.Data.StudentInformationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Course_Info Course_Info { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Course_Info.Add(Course_Info);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
